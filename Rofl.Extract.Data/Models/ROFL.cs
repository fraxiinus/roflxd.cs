using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Models;

public class ROFL : IReplay
{
    /// <summary>
    /// The 6 bytes all ROFL files begin with
    /// </summary>
    public static readonly byte[] Signature = { 0x52, 0x49, 0x4F, 0x54, 0x00, 0x00 };
    ///

    public ROFL()
    {
        LoadState = LoadState.Empty;
        ChunkHeaders = new List<ChunkHeader>();
        Chunks = new List<Chunk>();
    }

    public ROFL(LoadState loadState,
                byte[]? replaySignature,
                Lengths? lengths,
                Metadata? metadata,
                PayloadHeader? payloadHeader,
                IEnumerable<ChunkHeader> chunkHeaders,
                IEnumerable<Chunk> chunks)
    {
        LoadState = loadState;
        ReplaySignature = replaySignature;
        Lengths = lengths;
        Metadata = metadata;
        PayloadHeader = payloadHeader;
        ChunkHeaders = chunkHeaders;
        Chunks = chunks;
    }

    public async Task<string> ToFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default)
    {
        var outputFile = !string.IsNullOrEmpty(filePath)
                ? filePath
                : Path.GetFileNameWithoutExtension(inputFile.FullName) + $" - Copy {DateTime.Now:yyyyMMddTHHmmss}.rofl";

        using FileStream fileStream = new(outputFile, FileMode.Create);
        await fileStream.WriteAsync(ToBytes(), cancellationToken);

        return outputFile;
    }

    public async Task<string> ToJsonFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default)
    {
        var outputFile = !string.IsNullOrEmpty(filePath)
                ? filePath
                : Path.GetFileNameWithoutExtension(inputFile.FullName) + $" - Copy {DateTime.Now:yyyyMMddTHHmmss}.json";

        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        using FileStream fileStream = new(outputFile, FileMode.Create);
        await JsonSerializer.SerializeAsync(fileStream, this, jsonOptions, cancellationToken);

        return outputFile;
    }

    /// <summary>
    /// Convert the currently loaded ROFL data back to bytes, for verification purposes
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public byte[] ToBytes()
    {
        if (LoadState != LoadState.Full)
        {
            throw new Exception("cannot save file unless it has been fully loaded");
        }

        var chunkHeaderBytes = ChunkHeaders.Select(x => x.ToBytes())
            .Aggregate((a, b) => { return a.Concat(b).ToArray(); });

        var chunkBytes = Chunks.Select(x => x.ToBytes())
            .Aggregate((a, b) => { return a.Concat(b).ToArray(); });

        var bytesToWrite = Signature.Concat(ReplaySignature!)
            .Concat(Lengths!.ToBytes()).Concat(Metadata!.ToBytes())
            .Concat(PayloadHeader!.ToBytes()).Concat(chunkHeaderBytes)
            .Concat(chunkBytes).ToArray();

        return bytesToWrite;
    }

    // Class Properties

    public LoadState LoadState { get; private set; }

    // ROFL file contents

    public byte[]? ReplaySignature { get; private set; }

    public Lengths? Lengths { get; private set; }

    public Metadata? Metadata { get; private set; }

    public PayloadHeader? PayloadHeader { get; private set; }

    public IEnumerable<ChunkHeader> ChunkHeaders { get; private set; }

    public IEnumerable<Chunk> Chunks { get; private set; }
}

using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Models;

public enum LoadState
{
    /// <summary>
    /// Nothing loaded at all
    /// </summary>
    Empty,

    /// <summary>
    /// <see cref="ROFL.ChunkHeaders"/> and <see cref="ROFL.Chunks"/> are not loaded
    /// </summary>
    NoPayload,

    /// <summary>
    /// Everything is loaded
    /// </summary>
    Full
}

public class ROFL
{
    /// <summary>
    /// The 6 bytes all ROFL files begin with
    /// </summary>
    public static readonly byte[] Signature = { 0x52, 0x49, 0x4F, 0x54, 0x00, 0x00 };

    private static bool CheckFileSignature(byte[] headerBytes)
    {
        for (int i = 0; i < Signature.Length; i++)
        {
            if (Signature[i] != headerBytes[i])
            {
                return false;
            }
        }
        return true;
    }

    //

    private readonly string _filePath;

    public ROFL(string filePath)
    {
        _filePath = filePath;
        LoadState = LoadState.Empty;
        ChunkHeaders = new List<ChunkHeader>();
        Chunks = new List<Chunk>();
    }

    public async Task LoadAsync(bool loadAll = true)
    {
        await OpenFileForRead(loadAll);
    }

    /// <summary>
    /// Save the currently loaded ROFL data to file, for verification purposes
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public async Task SaveToFile(string filePath)
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

        using FileStream fileStream = new(filePath, FileMode.Create);
        await fileStream.WriteAsync(bytesToWrite);
    }

    private async Task OpenFileForRead(bool loadAll)
    {
        if (!File.Exists(_filePath))
        {
            throw new ArgumentException(nameof(_filePath));
        }

        using FileStream fileStream = new(_filePath, FileMode.Open);
        await LoadFromFileStream(fileStream, loadAll);
    }

    private async Task LoadFromFileStream(FileStream fileStream, bool loadAll)
    {
        if (!fileStream.CanRead)
        {
            throw new ArgumentException("cannot read from filestream", nameof(fileStream));
        }

        // read header, it is a known size of 288
        // in order to increase performance, do BIG READS instead of small ones
        byte[] headerBytes = await fileStream.ReadBytesAsync(288);
        
        if (!CheckFileSignature(headerBytes))
        {
            throw new Exception("file signature does not match ROFL format");
        }

        // replay signature is always 256 bytes
        ReplaySignature = headerBytes[6..262];
        // lengths fields are always 26 bytes
        Lengths = new Lengths(headerBytes[262..]);

        // what to read next depends on user
        int bytesLeft = (int)(Lengths.File - Lengths.Header); // read everything
        if (!loadAll)
        {
            bytesLeft = (int)(Lengths.Metadata + Lengths.PayloadHeader); // read just metadata and payload header
        }

        // ohhhh big read
        byte[] fileContentBytes = await fileStream.ReadBytesAsync(bytesLeft);

        Metadata = new Metadata(fileContentBytes[0..(int)Lengths.Metadata]);

        int payloadHeaderEnd = (int)(Lengths.Metadata + Lengths.PayloadHeader);
        PayloadHeader = new PayloadHeader(fileContentBytes[(int)Lengths.Metadata..payloadHeaderEnd]);

        if (loadAll)
        {
            var chunkHeaderResults = new List<ChunkHeader>();
            int chunkHeaderStart = 0;
            for (int i = 0; i < PayloadHeader.ChunkCount + PayloadHeader.KeyframeCount; i++)
            {
                // chunk headers are exactly 17 bytes
                chunkHeaderStart = payloadHeaderEnd + (17 * i);
                byte[] chunkHeaderBytes = fileContentBytes[chunkHeaderStart..(chunkHeaderStart + 17)];
                chunkHeaderResults.Add(new ChunkHeader(chunkHeaderBytes));
            }
            ChunkHeaders = chunkHeaderResults;

            var chunkResults = new List<Chunk>();
            int chunkOffset = chunkHeaderStart + 17; // count last chunk header
            for (int i = 0; i < ChunkHeaders.Count(); i++)
            {
                var chunkHeader = chunkHeaderResults[i];
                byte[] chunkBytes = fileContentBytes[chunkOffset..(int)(chunkOffset + chunkHeader.ChunkLength)];
                chunkResults.Add(new Chunk(chunkHeader.ChunkId, chunkHeader.ChunkType, chunkBytes));

                // chunk lengths are not uniform, add at the end
                chunkOffset += (int)chunkHeader.ChunkLength;
            }
            Chunks = chunkResults;

            LoadState = LoadState.Full;
        }
        else
        {
            LoadState = LoadState.NoPayload;
        }
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

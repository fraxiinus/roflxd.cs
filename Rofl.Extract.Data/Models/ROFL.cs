using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using System;
using System.Collections.Generic;
using System.Linq;

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

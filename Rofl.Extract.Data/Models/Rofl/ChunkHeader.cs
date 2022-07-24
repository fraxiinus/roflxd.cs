using System;
using System.Linq;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

public enum ChunkType { Keyframe, Chunk }

/// <summary>
/// Contains information required for reading chunk data
/// </summary>
public class ChunkHeader
{
    /// <summary>
    /// Input array should be 17 bytes in total, starting from <see cref="Lengths.PayloadOffset"/>
    /// </summary>
    /// <param name="byteData"></param>
    public ChunkHeader(byte[] byteData)
    {
        ChunkId = BitConverter.ToUInt32(byteData, 0);
        ChunkType = byteData[4] == 0x01 ? ChunkType.Keyframe : ChunkType.Chunk;
        ChunkLength = BitConverter.ToUInt32(byteData, 5);
        NextChunkId = BitConverter.ToUInt32(byteData, 9);
        Offset = BitConverter.ToUInt32(byteData, 13);
    }

    /// <summary>
    /// Returns this data structure back to bytes
    /// </summary>
    public byte[] ToBytes()
    {
        var chunkIdBytes = BitConverter.GetBytes(ChunkId);
        byte[] chunkTypeBytes = new byte[] { ChunkType == ChunkType.Keyframe ? (byte)0x01 : (byte)0x02 };
        var chunkLengthBytes = BitConverter.GetBytes(ChunkLength);
        var nextChunkIdBytes = BitConverter.GetBytes(NextChunkId);
        var offsetBytes = BitConverter.GetBytes(Offset);

        return chunkIdBytes.Concat(chunkTypeBytes)
            .Concat(chunkLengthBytes).Concat(nextChunkIdBytes)
            .Concat(offsetBytes).ToArray();
    }

    /// <summary>
    /// Chunk ID, unique to type
    /// </summary>
    public uint ChunkId { get; private set; }

    /// <summary>
    /// Chunk type
    /// </summary>
    public ChunkType ChunkType { get; private set; }

    /// <summary>
    /// Size of chunk in bytes
    /// </summary>
    public uint ChunkLength { get; private set; }

    /// <summary>
    /// The next chunk ID, 0 for keyframes
    /// </summary>
    public uint NextChunkId { get; private set; }

    /// <summary>
    /// Offset to chunk from beginning of file
    /// </summary>
    public uint Offset { get; private set; }
}
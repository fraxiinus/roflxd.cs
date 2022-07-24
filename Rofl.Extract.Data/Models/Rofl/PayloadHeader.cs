using System;
using System.Linq;
using System.Text;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

/// <summary>
/// Contains information on how to play back the replay
/// </summary>
public class PayloadHeader
{
    /// <summary>
    /// Input array should be <see cref="Lengths.PayloadHeader"/> bytes in total, 
    /// starting at <see cref="Lengths.PayloadHeaderOffset"/>
    /// </summary>
    /// <param name="byteData"></param>
    public PayloadHeader(byte[] byteData)
    {
        GameId = BitConverter.ToUInt64(byteData, 0);
        GameLength = BitConverter.ToUInt32(byteData, 8);
        KeyframeCount = BitConverter.ToUInt32(byteData, 12);
        ChunkCount = BitConverter.ToUInt32(byteData, 16);
        EndStartupChunkId = BitConverter.ToUInt32(byteData, 20);
        StartGameChunkId = BitConverter.ToUInt32(byteData, 24);
        KeyframeInterval = BitConverter.ToUInt32(byteData, 28);
        EncryptionKeyLength = BitConverter.ToUInt16(byteData, 32);
        EncryptionKey = Encoding.UTF8.GetString(byteData, 34, EncryptionKeyLength);
    }

    /// <summary>
    /// Returns this data structure back to bytes
    /// </summary>
    public byte[] ToBytes()
    {
        var gameIdBytes = BitConverter.GetBytes(GameId);
        var gameLengthBytes = BitConverter.GetBytes(GameLength);
        var keyframeCountBytes = BitConverter.GetBytes(KeyframeCount);
        var chunkCountBytes = BitConverter.GetBytes(ChunkCount);
        var endStartupChunkIdBytes = BitConverter.GetBytes(EndStartupChunkId);
        var startGameChunkIdBytes = BitConverter.GetBytes(StartGameChunkId);
        var keyframeIntervalBytes = BitConverter.GetBytes(KeyframeInterval);
        var encryptionKeyLengthBytes = BitConverter.GetBytes(EncryptionKeyLength);
        var encryptionKeyBytes = Encoding.UTF8.GetBytes(EncryptionKey);

        return gameIdBytes.Concat(gameLengthBytes)
            .Concat(keyframeCountBytes).Concat(chunkCountBytes)
            .Concat(endStartupChunkIdBytes).Concat(startGameChunkIdBytes)
            .Concat(keyframeIntervalBytes).Concat(encryptionKeyLengthBytes)
            .Concat(encryptionKeyBytes).ToArray();
    }

    /// <summary>
    /// Match ID of the replay
    /// </summary>
    public ulong GameId { get; private set; }

    /// <summary>
    /// Duration of the game, in milliseconds, prefer <see cref="Metadata.GameLength"/>
    /// </summary>
    public uint GameLength { get; private set; }

    /// <summary>
    /// Number of keyframes in payload
    /// </summary>
    public uint KeyframeCount { get; private set; }

    /// <summary>
    /// Number of chunks in payload
    /// </summary>
    public uint ChunkCount { get; private set; }

    /// <summary>
    /// Chunk ID with unknown meaning
    /// </summary>
    public uint EndStartupChunkId { get; private set; }

    /// <summary>
    /// Chunk ID with unknown meaning
    /// </summary>
    public uint StartGameChunkId { get; private set; }

    /// <summary>
    /// Unknown
    /// </summary>
    public uint KeyframeInterval { get; private set; }

    /// <summary>
    /// Length of encryption key in bytes
    /// </summary>
    public ushort EncryptionKeyLength { get; private set; }

    /// <summary>
    /// Base64 encoded string
    /// </summary>
    public string EncryptionKey { get; private set; }
}

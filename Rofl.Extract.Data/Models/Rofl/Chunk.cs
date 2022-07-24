namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

/// <summary>
/// Represents a "Chunk" of payload data from the replay file
/// </summary>
public class Chunk
{
    public Chunk(uint id, ChunkType type, byte[] byteData)
    {
        Id = id;
        Data = byteData;
        Type = type;
    }

    /// <summary>
    /// Returns this data structure back to bytes
    /// </summary>
    public byte[] ToBytes()
    {
        return Data;
    }

    /// <summary>
    /// Chunk ID, unique to type
    /// </summary>
    public uint Id { get; private set; }

    /// <summary>
    /// Chunk type
    /// </summary>
    public ChunkType Type { get; private set; }

    /// <summary>
    /// Unknown format, presented as raw bytes
    /// </summary>
    public byte[] Data { get; private set; }
}
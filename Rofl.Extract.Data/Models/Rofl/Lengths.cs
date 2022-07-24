using System;
using System.Linq;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

/// <summary>
/// Contains lengths and offsets used to read the rest of the file
/// </summary>
public class Lengths
{
    /// <summary>
    /// Input array should be 26 bytes in total, starting from offset 262
    /// </summary>
    /// <param name="byteData"></param>
    public Lengths(byte[] byteData)
    {
        Header = BitConverter.ToUInt16(byteData, 0);
        File = BitConverter.ToUInt32(byteData, 2);
        MetadataOffset = BitConverter.ToUInt32(byteData, 6);
        Metadata = BitConverter.ToUInt32(byteData, 10);
        PayloadHeaderOffset = BitConverter.ToUInt32(byteData, 14);
        PayloadHeader = BitConverter.ToUInt32(byteData, 18);
        PayloadOffset = BitConverter.ToUInt32(byteData, 22);
    }

    /// <summary>
    /// Returns this data structure back to bytes
    /// </summary>
    public byte[] ToBytes()
    {
        var headerBytes = BitConverter.GetBytes(Header);
        var fileBytes = BitConverter.GetBytes(File);
        var metadataOffsetBytes = BitConverter.GetBytes(MetadataOffset);
        var metadataBytes = BitConverter.GetBytes(Metadata);
        var payloadHeaderOffsetBytes = BitConverter.GetBytes(PayloadHeaderOffset);
        var payloadHeaderBytes = BitConverter.GetBytes(PayloadHeader);
        var payloadOffsetBytes = BitConverter.GetBytes(PayloadOffset);

        return headerBytes.Concat(fileBytes)
            .Concat(metadataOffsetBytes).Concat(metadataBytes)
            .Concat(payloadHeaderOffsetBytes).Concat(payloadHeaderBytes)
            .Concat(payloadOffsetBytes).ToArray();
    }

    /// <summary>
    /// Length of header section in bytes
    /// </summary>
    public ushort Header { get; private set; }

    /// <summary>
    /// Length of entire file in bytes
    /// </summary>
    public uint File { get; private set; }

    /// <summary>
    /// Offset to metadata from beginning of file
    /// </summary>
    public uint MetadataOffset { get; private set; }

    /// <summary>
    /// Length of metadata section in bytes
    /// </summary>
    public uint Metadata { get; private set; }

    /// <summary>
    /// Offset to payload header from beginning of file
    /// </summary>
    public uint PayloadHeaderOffset { get; private set; }

    /// <summary>
    /// Length of payload header in bytes
    /// </summary>
    public uint PayloadHeader { get; private set; }

    /// <summary>
    /// Offset to payload from beginning of file
    /// </summary>
    public uint PayloadOffset { get; private set; }
}


using Fraxiinus.Rofl.Extract.Data.Models;
using Fraxiinus.Rofl.Extract.Data.Models.Rofl2;
using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Readers;

/// <summary>
/// Handles reading of ROFL2 replay formats
/// </summary>
public static class Rofl2Reader
{
    public static async Task<ROFL2> LoadAsync(string filePath, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        return await OpenFileForRead(filePath, options, cancellationToken);
    }

    public static async Task<ROFL2> LoadAsync(Stream stream, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        return await LoadFromStream(stream, options, cancellationToken);
    }

    private static async Task<ROFL2> OpenFileForRead(string filePath, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("file does not exist", nameof(filePath));
        }

        using FileStream fileStream = new(filePath, FileMode.Open);
        return await LoadFromStream(fileStream, options, cancellationToken);
    }

    private static async Task<ROFL2> LoadFromStream(Stream stream, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        if (!stream.CanRead)
        {
            throw new ArgumentException("cannot read from stream", nameof(stream));
        }

        // read version number from header
        byte[] gameVerionBytes = await stream.ReadBytesAsync(14, 15, SeekOrigin.Begin, cancellationToken);
        var gameVersion = Encoding.UTF8.GetString(gameVerionBytes);

        // read last 4 bytes to get metadata length
        byte[] metadataLengthBytes = await stream.ReadBytesAsync(4, -4, SeekOrigin.End, cancellationToken);
        var metadataLength = BitConverter.ToInt32(metadataLengthBytes);

        // read metadata using length value
        var metadataStart = -(metadataLength + 4);
        byte[] metadataBytes = await stream.ReadBytesAsync(metadataLength, metadataStart, SeekOrigin.End, cancellationToken);

        var metadata = new Metadata2(metadataBytes, gameVersion);
        return new ROFL2(LoadState.NoPayload, metadata);
    }
}
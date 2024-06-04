using Fraxiinus.Rofl.Extract.Data.Models;
using Fraxiinus.Rofl.Extract.Data.Readers;
using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data;

public enum ReplayType { Unknown, ROFL, ROFL2 };

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

public static class ReplayReader
{
    public static async Task<ParseResult> ReadReplay(string filePath, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        using FileStream fileStream = new(filePath, FileMode.Open);
        return await ReadReplay(fileStream, options, cancellationToken);
    }

    public static async Task<ParseResult> ReadReplay(Stream fileStream, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        // if replay file type is unknown, then auto detect type
        var replayType = options.Type == ReplayType.Unknown ? await DetectReplayTypeAsync(fileStream, cancellationToken) : options.Type;

        IReplay? replay = null;
        switch (replayType)
        {
            case ReplayType.ROFL2:
                replay = await Rofl2Reader.LoadAsync(fileStream, options, cancellationToken);
                break;
            case ReplayType.ROFL:
                replay = await RoflReader.LoadAsync(fileStream, options, cancellationToken);
                break;
        }

        return new ParseResult(replay, replayType);
    }

    public static async Task<ReplayType> DetectReplayType(string filePath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("file does not exist", nameof(filePath));
        }

        using FileStream fileStream = new(filePath, FileMode.Open);
        return await DetectReplayTypeAsync(fileStream, cancellationToken);
    }

    public static async Task<ReplayType> DetectReplayTypeAsync(Stream fileStream, CancellationToken cancellationToken = default)
    {
        if (!fileStream.CanRead)
        {
            throw new ArgumentException("cannot read from stream", nameof(fileStream));
        }

        // read bytes which contain file signature
        byte[] signatureBytes = await fileStream.ReadBytesAsync(6, 0, SeekOrigin.Begin, cancellationToken);
        return DetectReplayType(signatureBytes);
    }

    public static ReplayType DetectReplayType(byte[] signatureBytes)
    {
        if (IsROFL2Signature(signatureBytes))
        {
            return ReplayType.ROFL2;
        }
        else if (IsROFLSignature(signatureBytes))
        {
            return ReplayType.ROFL;
        }
        else
        {
            throw new ArgumentException("signature does not match any known file types");
        }
    }

    private static bool IsROFL2Signature(byte[] signatureBytes)
    {
        for (int i = 0; i < ROFL2.Signature.Length; i++)
        {
            if (ROFL2.Signature[i] != signatureBytes[i])
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsROFLSignature(byte[] signatureBytes)
    {
        for (int i = 0; i < ROFL.Signature.Length; i++)
        {
            if (ROFL.Signature[i] != signatureBytes[i])
            {
                return false;
            }
        }
        return true;
    }
}

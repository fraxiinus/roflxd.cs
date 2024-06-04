using Fraxiinus.Rofl.Extract.Data.Models;
using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Readers;

/// <summary>
/// Handles reading of ROFL replay formats
/// </summary>
public class RoflReader
{
    public static async Task<ROFL> LoadAsync(string filePath, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        return await OpenFileForRead(filePath, options, cancellationToken);
    }

    public static async Task<ROFL> LoadAsync(Stream stream, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        return await LoadFromStream(stream, options, cancellationToken);
    }

    private static async Task<ROFL> OpenFileForRead(string filePath, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("file does not exist", nameof(filePath));
        }

        using FileStream fileStream = new(filePath, FileMode.Open);
        return await LoadFromStream(fileStream, options, cancellationToken);
    }

    private static async Task<ROFL> LoadFromStream(Stream stream, ReplayReaderOptions options, CancellationToken cancellationToken = default)
    {
        if (!stream.CanRead)
        {
            throw new ArgumentException("cannot read from stream", nameof(stream));
        }

        // read header, it is a known size of 288
        // in order to increase performance, do BIG READS instead of small ones
        byte[] headerBytes = await stream.ReadBytesAsync(288, cancellationToken);

        if (!CheckFileSignature(headerBytes))
        {
            throw new Exception("file signature does not match ROFL format");
        }

        // replay signature is always 256 bytes
        var replaySignature = headerBytes[6..262];
        // lengths fields are always 26 bytes
        var lengths = new Lengths(headerBytes[262..]);

        // what to read next depends on user
        int bytesLeft = (int)(lengths.File - lengths.Header); // read everything
        if (!options.LoadPayload)
        {
            bytesLeft = (int)(lengths.Metadata + lengths.PayloadHeader); // read just metadata and payload header
        }

        // ohhhh big read
        byte[] fileContentBytes = await stream.ReadBytesAsync(bytesLeft, cancellationToken);

        var metadata = new Metadata(fileContentBytes[0..(int)lengths.Metadata]);

        int payloadHeaderEnd = (int)(lengths.Metadata + lengths.PayloadHeader);
        var payloadHeader = new PayloadHeader(fileContentBytes[(int)lengths.Metadata..payloadHeaderEnd]);
        var chunkHeaders = new List<ChunkHeader>();
        var chunks = new List<Chunk>();
        LoadState loadState;

        if (options.LoadPayload)
        {
            var chunkHeaderResults = new List<ChunkHeader>();
            int chunkHeaderStart = 0;
            for (int i = 0; i < payloadHeader.ChunkCount + payloadHeader.KeyframeCount; i++)
            {
                // chunk headers are exactly 17 bytes
                chunkHeaderStart = payloadHeaderEnd + 17 * i;
                byte[] chunkHeaderBytes = fileContentBytes[chunkHeaderStart..(chunkHeaderStart + 17)];
                chunkHeaderResults.Add(new ChunkHeader(chunkHeaderBytes));
            }
            chunkHeaders = chunkHeaderResults;

            var chunkResults = new List<Chunk>();
            int chunkOffset = chunkHeaderStart + 17; // count last chunk header
            for (int i = 0; i < chunkHeaders.Count; i++)
            {
                var chunkHeader = chunkHeaderResults[i];
                byte[] chunkBytes = fileContentBytes[chunkOffset..(int)(chunkOffset + chunkHeader.ChunkLength)];
                chunkResults.Add(new Chunk(chunkHeader.ChunkId, chunkHeader.ChunkType, chunkBytes));

                // chunk lengths are not uniform, add at the end
                chunkOffset += (int)chunkHeader.ChunkLength;
            }
            chunks = chunkResults;

            loadState = LoadState.Full;
        }
        else
        {
            loadState = LoadState.NoPayload;
        }

        return new ROFL(loadState,
                        replaySignature,
                        lengths,
                        metadata,
                        payloadHeader,
                        chunkHeaders,
                        chunks);
    }

    private static bool CheckFileSignature(byte[] headerBytes)
    {
        for (int i = 0; i < ROFL.Signature.Length; i++)
        {
            if (ROFL.Signature[i] != headerBytes[i])
            {
                return false;
            }
        }
        return true;
    }
}


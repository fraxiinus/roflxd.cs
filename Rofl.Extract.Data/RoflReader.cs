using Fraxiinus.Rofl.Extract.Data.Models;
using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data;

public static class RoflReader
{
    public static async Task<ROFL> LoadAsync(string filePath, bool loadAll = false, CancellationToken cancellationToken = default)
    {
        return await OpenFileForRead(filePath, loadAll, cancellationToken);
    }

    public static async Task<ROFL> LoadAsync(Stream stream, bool loadAll = false, CancellationToken cancellationToken = default)
    {
        return await LoadFromStream(stream, loadAll, cancellationToken);
    }

    private static async Task<ROFL> OpenFileForRead(string filePath, bool loadAll, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("file does not exist", nameof(filePath));
        }

        using FileStream fileStream = new(filePath, FileMode.Open);
        return await LoadFromStream(fileStream, loadAll, cancellationToken);
    }

    private static async Task<ROFL> LoadFromStream(Stream stream, bool loadAll, CancellationToken cancellationToken = default)
    {
        if (!stream.CanRead)
        {
            throw new ArgumentException("cannot read from stream", nameof(stream));
        }

        // The new replay files seem to have the same header of size 48 bytes
        stream.Position = 15; // At the 15th byte is the 14 byte version of the game
        byte[] buffer = new byte[14]; // The game version is 14 bytes long
        await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
        string gameVersion = Encoding.UTF8.GetString(buffer);

        LoadState loadState = LoadState.Empty;
        byte[] pattern = new byte[] { 0x7B, 0x22, 0x67, 0x61, 0x6D, 0x65, 0x4C, 0x65, 0x6E, 0x67, 0x74, 0x68, 0x22 };
        Metadata metadata;

        using (MemoryStream ms = new MemoryStream(1000))
        {
            await stream.CopyToAsync(ms, cancellationToken);
            byte[] content = ms.ToArray();
            int position = IndexOf(content, pattern);

            if (position != -1)
            {
                byte[] newContent = content[position..^4];
                metadata = new(newContent);
            }
            else
            {
                throw new Exception("Pattern not found");
            }
        }

        loadState = LoadState.Full;

        return new ROFL(loadState, gameVersion, metadata);

        // I let the original code commented if someone find the location of offsets but for me there is no more offsets in the new replay files
        // if (!stream.CanRead)
        // {
        //     throw new ArgumentException("cannot read from stream", nameof(stream));
        // }

        // // read header, it is a known size of 288
        // // in order to increase performance, do BIG READS instead of small ones
        // byte[] headerBytes = await stream.ReadBytesAsync(288, cancellationToken);

        // if (!CheckFileSignature(headerBytes))
        // {
        //     throw new Exception("file signature does not match ROFL format");
        // }

        // // replay signature is always 256 bytes
        // var replaySignature = headerBytes[6..262];
        // // lengths fields are always 26 bytes
        // var lengths = new Lengths(headerBytes[262..]);

        // // what to read next depends on user
        // int bytesLeft = (int)(lengths.File - lengths.Header); // read everything
        // if (!loadAll)
        // {
        //     bytesLeft = (int)(lengths.Metadata + lengths.PayloadHeader); // read just metadata and payload header
        // }

        // // ohhhh big read
        // byte[] fileContentBytes = await stream.ReadBytesAsync(bytesLeft, cancellationToken);

        // var metadata = new Metadata(fileContentBytes[0..(int)lengths.Metadata]);

        // int payloadHeaderEnd = (int)(lengths.Metadata + lengths.PayloadHeader);
        // var payloadHeader = new PayloadHeader(fileContentBytes[(int)lengths.Metadata..payloadHeaderEnd]);
        // var chunkHeaders = new List<ChunkHeader>();
        // var chunks = new List<Chunk>();
        // LoadState loadState;

        // if (loadAll)
        // {
        //     var chunkHeaderResults = new List<ChunkHeader>();
        //     int chunkHeaderStart = 0;
        //     for (int i = 0; i < payloadHeader.ChunkCount + payloadHeader.KeyframeCount; i++)
        //     {
        //         // chunk headers are exactly 17 bytes
        //         chunkHeaderStart = payloadHeaderEnd + (17 * i);
        //         byte[] chunkHeaderBytes = fileContentBytes[chunkHeaderStart..(chunkHeaderStart + 17)];
        //         chunkHeaderResults.Add(new ChunkHeader(chunkHeaderBytes));
        //     }
        //     chunkHeaders = chunkHeaderResults;

        //     var chunkResults = new List<Chunk>();
        //     int chunkOffset = chunkHeaderStart + 17; // count last chunk header
        //     for (int i = 0; i < chunkHeaders.Count; i++)
        //     {
        //         var chunkHeader = chunkHeaderResults[i];
        //         byte[] chunkBytes = fileContentBytes[chunkOffset..(int)(chunkOffset + chunkHeader.ChunkLength)];
        //         chunkResults.Add(new Chunk(chunkHeader.ChunkId, chunkHeader.ChunkType, chunkBytes));

        //         // chunk lengths are not uniform, add at the end
        //         chunkOffset += (int)chunkHeader.ChunkLength;
        //     }
        //     chunks = chunkResults;

        //     loadState = LoadState.Full;
        // }
        // else
        // {
        //     loadState = LoadState.NoPayload;
        // }

        // return new ROFL(loadState,
        //                 replaySignature,
        //                 lengths,
        //                 metadata,
        //                 payloadHeader,
        //                 chunkHeaders,
        //                 chunks);
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

    private static int IndexOf(byte[] haystack, byte[] needle)
    {
        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                {
                    found = false;
                    break;
                }
            }

            if (found) return i;
        }

        return -1;
    }
}


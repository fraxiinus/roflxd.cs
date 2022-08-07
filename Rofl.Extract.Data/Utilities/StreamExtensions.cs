using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Utilities;

public static class StreamExtensions
{
    public static async Task<byte[]> ReadBytesAsync(this FileStream fileStream, int count, CancellationToken cancellationToken = default)
    {
        byte[] buffer = new byte[count];

        await fileStream.ReadAsync(buffer.AsMemory(0, count), cancellationToken);

        if (buffer.Length != count)
        {
            throw new Exception("did not read correct amount of bytes");
        }
        return buffer;
    }

    public static async Task<byte[]> ReadBytesAsync(this FileStream fileStream, int count, int offset, SeekOrigin origin, CancellationToken cancellationToken = default)
    {
        byte[] buffer = new byte[count];

        fileStream.Seek(offset, origin);
        await fileStream.ReadAsync(buffer.AsMemory(0, count), cancellationToken);

        if (buffer.Length != count)
        {
            throw new Exception("did not read correct amount of bytes");
        }
        return buffer;
    }
}
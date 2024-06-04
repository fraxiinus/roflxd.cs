using Fraxiinus.Rofl.Extract.Data.Models.Rofl2;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Models;

public class ROFL2 : IReplay
{
    /// <summary>
    /// Assumed 6 bytes ROFL2 files begin with
    /// </summary>
    public static readonly byte[] Signature = { 0x52, 0x49, 0x4F, 0x54, 0x02, 0x00 };
    ///

    public ROFL2()
    {
        LoadState = LoadState.Empty;
    }

    public ROFL2(LoadState loadState,
                Metadata2? metadata)
    {
        LoadState = loadState;
        Metadata = metadata;
    }

    public byte[] ToBytes()
    {
        throw new NotImplementedException();
    }

    public Task<string> ToFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<string> ToJsonFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default)
    {
        var outputFile = !string.IsNullOrEmpty(filePath)
                ? filePath
                : Path.GetFileNameWithoutExtension(inputFile.FullName) + $" - Copy {DateTime.Now:yyyyMMddTHHmmss}.json";

        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        using FileStream fileStream = new(outputFile, FileMode.Create);
        await JsonSerializer.SerializeAsync(fileStream, this, jsonOptions, cancellationToken);

        return outputFile;
    }

    // Class Properties

    public LoadState LoadState { get; private set; }

    public Metadata2? Metadata { get; private set; }
}

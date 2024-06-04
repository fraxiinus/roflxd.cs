using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.Models;

public interface IReplay
{
    LoadState LoadState { get; }

    byte[] ToBytes();

    Task<string> ToFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default);

    Task<string> ToJsonFile(FileInfo inputFile, string filePath, CancellationToken cancellationToken = default);
}

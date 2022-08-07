using Fraxiinus.ReplayBook.Reader;
using Rofl.Reader;
using Rofl.Reader.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.BenchmarkApp;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("roflxd.cs Benchmarking Application");
        Console.Write("Enter target folder:");

        var targetFolder = Console.ReadLine();

        if (!Directory.Exists(targetFolder))
        {
            Console.WriteLine("Folder not found");
            return;
        }

        var files = Directory.EnumerateFiles(targetFolder, "*.rofl", SearchOption.AllDirectories);
        Console.WriteLine($"Found {files.Count()} rofl files");

        Console.WriteLine("-- Starting roflxd.cs test --");

        var failures = 0;
        var count = 0;
        var timer = new Stopwatch();
        timer.Start();
        foreach (var replayPath in files)
        {
            var result = await RunRoflXDTest(replayPath);
            Console.Write($"\rRead file: {result}");
            count++;
            if (result == "FAILURE")
            {
                failures++;
            }
        }
        timer.Stop();
        Console.WriteLine($"\nDone in {timer.ElapsedMilliseconds / 1000f}s! with {failures}/{count} failures");

        Console.WriteLine("-- Starting ReplayReader (ReplayBook) test --");

        failures = 0;
        count = 0;
        timer = new Stopwatch();
        timer.Start();
        foreach (var replayPath in files)
        {
            var result = await RunRoflReaderRBTest(replayPath);
            Console.Write($"\rRead file: {result}");
            count++;
            if (result == "FAILURE")
            {
                failures++;
            }
        }
        timer.Stop();
        Console.WriteLine($"\nDone in {timer.ElapsedMilliseconds / 1000f}s! with {failures}/{count} failures");

        Console.WriteLine("-- Starting ReplayReader (ROFL-Player) test --");

        failures = 0;
        count = 0;
        timer = new Stopwatch();
        timer.Start();
        foreach (var replayPath in files)
        {
            var result = await RunRoflReaderRPTest(replayPath);
            Console.Write($"\rRead file: {result}");
            count++;
            if (result == "FAILURE")
            {
                failures++;
            }
        }
        timer.Stop();
        Console.WriteLine($"\nDone in {timer.ElapsedMilliseconds / 1000f}s! with {failures}/{count} failures");
    }

    public static async Task<string> RunRoflXDTest(string replayPath)
    {
        try
        {
            var rofl = await RoflReader.LoadAsync(replayPath, false);
            return rofl.PayloadHeader!.GameId.ToString();
        }
        catch (Exception)
        {
            return "FAILURE";
        }
    }

    public static async Task<string> RunRoflReaderRBTest(string replayPath)
    {
        try
        {
            var reader = new ReplayReaderRB();
            var rofl = await reader.ReadROFL(replayPath);
            return rofl.MatchId.ToString();
        }
        catch (Exception)
        {

            return "FAILURE";
        }
    }

    public static async Task<string> RunRoflReaderRPTest(string replayPath)
    {
        try
        {
            var target = new ReplayFile
            {
                Name = Path.GetFileName(replayPath),
                Location = replayPath,
                Type = REPLAYTYPES.ROFL
            };
            
            var reader = new ReplayReaderRP();
            var rofl = await reader.ReadFile(target);
            return rofl.Data.PayloadFields.MatchId.ToString();
        }
        catch (Exception)
        {

            return "FAILURE";
        }
    }
}
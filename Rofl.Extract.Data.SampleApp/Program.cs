using Fraxiinus.Rofl.Extract.Data.Models;
using System;
using System.CommandLine;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.SampleApp;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var inputArg = new Argument<FileInfo?>(
            name: "input",
            description: "The replay file to read");

        var modeOption = new Option<string>(
            name: "--mode",
            description: "ROFL load mode",
            getDefaultValue: () => "full")
                .FromAmong(
                        "full",
                        "nopayload"
                    );

        var verifyOption = new Option<bool>(
            name: "--verify",
            description: "Output loaded data in memory to new ROFL file");

        var outputOption = new Option<string>(
            name: "--output",
            description: "Change the destination for the output file. ROFL file in verify mode, JSON file otherwise",
            getDefaultValue: () => string.Empty);

        var verboseOption = new Option<bool>(
            name: "--verbose",
            description: "Show verbose information");

        var parseCommand = new Command("parse", "Parse input replay file")
            {
                inputArg,
                modeOption,
                verifyOption,
                outputOption,
                verboseOption
            };

        var rootCommand = new RootCommand("Sample app for Fraxiinus.Rofl.Extract.Data (roflxd.cs)")
        {
            parseCommand
        };

        parseCommand.SetHandler(async (input, mode, verify, output, verbose) =>
            {
                await HandleCommand(input!, mode, verify, output, verbose);
            },
            inputArg, modeOption, verifyOption, outputOption, verboseOption);

        return await rootCommand.InvokeAsync(args);
    }

    public static async Task HandleCommand(FileInfo file, string mode, bool verify, string output, bool verbose)
    {
        if (!File.Exists(file.FullName))
        {
            Console.WriteLine("input file does not exist");
            return;
        }

        var target = new ROFL(file.FullName);
        var loadAll = mode == "full";
        var timer = new Stopwatch();

        if (verbose)
        {
            Console.Write($"Parsing file in \"{mode}\" mode...");
            timer.Start();
        }

        await target.LoadAsync(loadAll);

        if (verbose)
        {
            timer.Stop();
            Console.WriteLine($"done in {timer.ElapsedMilliseconds / 1000f}s!");
        }

        if (verify)
        {
            if (!loadAll)
            {
                Console.WriteLine("Cannot verify file without doing a full load!");
                return;
            }
            var outputFile = !string.IsNullOrEmpty(output)
                ? output
                : Path.GetFileNameWithoutExtension(file.FullName) + $" - Copy {DateTime.Now:yyyyMMddTHHmmss}.rofl";
            await target.SaveToFile(outputFile);

            if (verbose)
            {
                Console.Write($"Saved file: \"{outputFile}\"");
            }
        }
        else
        {
            var outputFile = !string.IsNullOrEmpty(output)
                ? output
                : Path.GetFileNameWithoutExtension(file.FullName) + $" - Copy {DateTime.Now:yyyyMMddTHHmmss}.json";

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            using FileStream fileStream = new(outputFile, FileMode.Create);
            JsonSerializer.Serialize(fileStream, target, jsonOptions);

            if (verbose)
            {
                Console.Write($"Saved file: \"{outputFile}\"");
            }
        }
    }
}
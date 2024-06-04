using Fraxiinus.Rofl.Extract.Data.Models;
using System;
using System.CommandLine;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fraxiinus.Rofl.Extract.Data.SampleApp;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var inputArg = new Argument<FileInfo?>(
            name: "input",
            description: "The replay file to read");

        var fileTypeOption = new Option<string>(
            name: "--type",
            description: "specify replay type",
            getDefaultValue: () => "auto")
                .FromAmong(
                        "auto",
                        "rofl",
                        "rofl2"
                    );

        var modeOption = new Option<string>(
            name: "--mode",
            description: "replay load mode",
            getDefaultValue: () => "full")
                .FromAmong(
                        "full",
                        "nopayload"
                    );

        var verifyOption = new Option<bool>(
            name: "--verify",
            description: "Output loaded data in memory to copy of replay file");

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
                fileTypeOption,
                modeOption,
                verifyOption,
                outputOption,
                verboseOption
            };

        var rootCommand = new RootCommand("Sample app for Fraxiinus.Rofl.Extract.Data (roflxd.cs)")
        {
            parseCommand
        };

        parseCommand.SetHandler(async (input, type, mode, verify, output, verbose) =>
            {
                await HandleCommand(input!, type, mode, verify, output, verbose);
            },
            inputArg, fileTypeOption, modeOption, verifyOption, outputOption, verboseOption);

        return await rootCommand.InvokeAsync(args);
    }

    public static async Task HandleCommand(FileInfo file, string type, string mode, bool verify, string output, bool verbose, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(file.FullName))
        {
            Console.WriteLine("input file does not exist");
            return;
        }

        // start timer
        var timer = new Stopwatch();

        if (verbose)
        {
            Console.Write($"Parsing file in \"{mode}\" mode...");
            timer.Start();
        }

        // create options file
        var options = new ReplayReaderOptions
        {
            LoadPayload = mode == "full",
            OutputFileDestination = output,
            Verbose = verbose,
            Verify = verify,
            Type = TypeStringToEnum(type)
        };

        // Parse file using provided options
        var target = await ReplayReader.ReadReplay(file.FullName, options, cancellationToken);

        if (target.Type is ReplayType.Unknown || target.Result is null)
        {
            Console.WriteLine("failed to read file");
            return;
        }

        if (verbose)
        {
            timer.Stop();
            Console.WriteLine($"done in {timer.ElapsedMilliseconds / 1000f}s!");
        }

        if (verify)
        {
            if (!options.LoadPayload)
            {
                Console.WriteLine("Cannot verify file without doing a full load!");
                return;
            }
            
            switch (target.Type)
            {
                // lol rofl2 doesn't support payload reading oh well
                case ReplayType.ROFL:
                    var outputFile = await ((ROFL) target.Result).ToFile(file, output, cancellationToken);
                    if (verbose)
                    {
                        Console.Write($"Saved file: \"{outputFile}\"");
                    }
                    break;
            }
        }
        else
        {
            switch (target.Type)
            {
                case ReplayType.ROFL:
                    var outputFile = await ((ROFL)target.Result).ToJsonFile(file, output, cancellationToken);
                    if (verbose)
                    {
                        Console.Write($"Saved file: \"{outputFile}\"");
                    }
                    break;
                case ReplayType.ROFL2:
                    outputFile = await ((ROFL2)target.Result).ToJsonFile(file, output, cancellationToken);
                    if (verbose)
                    {
                        Console.Write($"Saved file: \"{outputFile}\"");
                    }
                    break;
            }
        }
    }

    private static ReplayType TypeStringToEnum(string type)
    {
        return type switch
        {
            "rofl" => ReplayType.ROFL,
            "rofl2" => ReplayType.ROFL2,
            _ => ReplayType.Unknown,
        };
    }
}
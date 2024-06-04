# roflxd.cs - ROFL eXtract Data (C# vers.)

[Go back to roflxd overview](https://github.com/fraxiinus/roflxd)

A complete ROFL parser for C#, supports both ROFL (pre 14.9) and ROFL2 (14.11+).

## Installing

[nuget.org package listing](https://www.nuget.org/packages/Fraxiinus.Rofl.Extract.Data)

Package Manager

```powershell
Install-Package Fraxiinus.Rofl.Extract.Data
```

.NET CLI

```powershell
dotnet add package Fraxiinus.Rofl.Extract.Data
```

## Usage

Use the `ReplayReader` class to read replay files by running the `ReadReplayAsync` method with the file path.

```C#
var replay = await ReplayReader.ReadReplayAsync("C:\\Documents\\File.rofl", options);
```

If the payload is required, use the optional parameter to let the parser know to not skip it (only supported by pre-14.9 replays):

```C#
var replay = await RoflReader.LoadAsync("C:\\Documents\\File.rofl", options);
```

Once the file is loaded, you are free to access the parsed data:

```C#
Console.WriteLine(((ROFL2) replay.Result).Metadata.GameVersion);
```

All the async functions support CancellationTokens.

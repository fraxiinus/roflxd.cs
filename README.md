# roflxd.cs - ROFL eXtract Data (C# vers.)

[Go back to roflxd overview](https://github.com/fraxiinus/roflxd)

A complete ROFL parser for C#

## Installing

Package Manager

```powershell
Install-Package Fraxiinus.Rofl.Extract.Data
```

.NET CLI

```bash
dotnet add package Fraxiinus.Rofl.Extract.Data
```

## Usage

Use the `RoflReader` class to read ROFL files by running the `LoadAsync` method with the file path.

```C#
var replay = await RoflReader.LoadAsync("C:\\Documents\\File.rofl");
```

If the payload is required, use the optional parameter to let the parser know to not skip it:

```C#
var replay = await RoflReader.LoadAsync("C:\\Documents\\File.rofl", loadAll: true);
```

Once the file is loaded, you are free to access the parsed data:

```C#
Console.WriteLine(replay.PayloadHeader!.GameId);
```

All the async functions support CancellationTokens.

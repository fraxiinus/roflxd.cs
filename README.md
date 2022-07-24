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

Create a `ROFL` object with the desired filepath, then run the `LoadAsync` method.

```C#
var replay = new ROFL("C:\\Documents\\File.rofl");
await replay.LoadAsync();
```

If the payload is not required, use the optional parameter to only skip it:

```C#
await replay.LoadAsync(loadAll: false);
```

Once the file is loaded, you are free to access the parsed data:

```C#
Console.WriteLine(rofl.PayloadHeader!.GameId);
```

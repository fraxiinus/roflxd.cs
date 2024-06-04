namespace Fraxiinus.Rofl.Extract.Data;

public class ReplayReaderOptions
{
    public ReplayType Type { get; set; }

    public bool LoadPayload { get; set; }

    public bool Verify { get; set; }

    public bool Verbose { get; set; }

    public string OutputFileDestination { get; set; } = string.Empty;
}

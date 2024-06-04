namespace Fraxiinus.Rofl.Extract.Data.Models;

public class ParseResult
{
    public ParseResult(IReplay? replay, ReplayType type)
    {
        Result = replay;
        Type = type;
    }

    public ReplayType Type { get; private set; }

    public IReplay? Result { get; private set; }
}

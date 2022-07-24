using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fraxiinus.Rofl.Extract.Data.Utilities;

public class ScientificNotationConverter : JsonConverter<ulong>
{
    public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TryGetUInt64(out var result) ? result : Convert.ToUInt64(reader.GetDecimal());
    }

    public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}

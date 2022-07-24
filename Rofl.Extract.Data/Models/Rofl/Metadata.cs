using Fraxiinus.Rofl.Extract.Data.Utilities;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

/// <summary>
/// Contains information about the game and players
/// </summary>
public class Metadata
{
    /// <summary>
    /// Input array should be <see cref="Lengths.Metadata"/> bytes in total, 
    /// starting at <see cref="Lengths.MetadataOffset"/>
    /// </summary>
    /// <param name="byteData"></param>
    /// <exception cref="Exception"></exception>
    public Metadata(byte[] byteData)
    {
        var jsonString = Encoding.UTF8.GetString(byteData);

        var options = new JsonSerializerOptions
        {
            Converters = { new ScientificNotationConverter() }
        };

        var rawMetadata = JsonSerializer.Deserialize<RawMetadata>(jsonString, options)
            ?? throw new Exception("RawMetadata parsed to null");

        GameLength = rawMetadata.GameLength;
        GameVersion = rawMetadata.GameVersion!;
        LastGameChunkId = rawMetadata.LastGameChunkId;
        LastKeyframeId = rawMetadata.LastKeyframeId;

        PlayerStatistics = JsonSerializer.Deserialize<PlayerStats[]>(rawMetadata.StatsJson!)
            ?? throw new Exception("PlayerStats[] parsed to null");
    }

    /// <summary>
    /// Returns this data structure back to bytes
    /// </summary>
    public byte[] ToBytes()
    {
        var playerStatsJson = JsonSerializer.Serialize(PlayerStatistics);
        var rawMetadata = new RawMetadata
        {
            GameLength = GameLength,
            GameVersion = GameVersion,
            LastGameChunkId = LastGameChunkId,
            LastKeyframeId = LastKeyframeId,
            StatsJson = playerStatsJson
        };

        var jsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        var metadataJson = JsonSerializer.Serialize(rawMetadata, jsonOptions);
        return Encoding.UTF8.GetBytes(metadataJson);
    }

    /// <summary>
    /// Duration of the game, in milliseconds
    /// </summary>
    public ulong GameLength { get; private set; }

    /// <summary>
    /// Patch version the game occurred on
    /// </summary>
    public string GameVersion { get; private set; }

    /// <summary>
    /// Chunk ID of the last chunk
    /// </summary>
    public uint LastGameChunkId { get; private set; }

    /// <summary>
    /// Keyframe ID of the last keyframe
    /// </summary>
    public uint LastKeyframeId { get; private set; }

    /// <summary>
    /// Array of player information and stats
    /// </summary>
    public PlayerStats[] PlayerStatistics { get; private set; }
}

public class RawMetadata
{
    [JsonPropertyName("gameLength")]
    public ulong GameLength { get; set; }

    [JsonPropertyName("gameVersion")]
    public string? GameVersion { get; set; }

    [JsonPropertyName("lastGameChunkId")]
    public uint LastGameChunkId { get; set; }

    [JsonPropertyName("lastKeyFrameId")]
    public uint LastKeyframeId { get; set; }

    [JsonPropertyName("statsJson")]
    public string? StatsJson { get; set; }
}

using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using System.Text.Json.Serialization;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl2;

/// <summary>
/// Contains all player information
/// </summary>
public class PlayerStats2 : PlayerStats
{
    [JsonPropertyName("Missions_ChampionsKilled")]
    public string? MissionsChampionsKilled { get; set; }

    [JsonPropertyName("Missions_CreepScore")]
    public string? MissionsCreepScore { get; set; }

    [JsonPropertyName("Missions_GoldFromStructuresDestroyed")]
    public string? MissionsGoldFromStructuresDestroyed { get; set; }

    [JsonPropertyName("Missions_GoldFromTurretPlatesTaken")]
    public string? MissionsGoldFromTurretPlatesTaken { get; set; }

    [JsonPropertyName("Missions_HealingFromLevelObjects")]
    public string? MissionsHealingFromLevelObjects { get; set; }

    [JsonPropertyName("Missions_MinionsKilled")]
    public string? MissionsMinionsKilled { get; set; }

    [JsonPropertyName("Missions_TurretPlatesDestroyed")]
    public string? MissionsTurretPlatesDestroyed { get; set; }
}

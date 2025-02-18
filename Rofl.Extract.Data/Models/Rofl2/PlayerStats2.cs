using Fraxiinus.Rofl.Extract.Data.Models.Rofl;
using System.Text.Json.Serialization;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl2;

/// <summary>
/// Contains all player information
/// </summary>
public class PlayerStats2 : PlayerStats
{
    [JsonPropertyName("Event_2025LR_StructuresEpicMonsters")]
    public string? Event2025LRStructuresEpicMonsters { get; set; }

    [JsonPropertyName("Missions_CannonMinionsKilled")]
    public string? MissionsCannonMinionsKilled { get; set; }

    [JsonPropertyName("Missions_ChampionTakedownsWhileGhosted")]
    public string? MissionsChampionTakedownsWhileGhosted { get; set; }

    [JsonPropertyName("Missions_ChampionTakedownsWithIgnite")]
    public string? MissionsChampionTakedownsWithIgnite { get; set; }

    [JsonPropertyName("Missions_ChampionsHitWithAbilitiesEarlyGame")]
    public string? MissionsChampionsHitWithAbilitiesEarlyGame { get; set; }

    [JsonPropertyName("Missions_ChampionsKilled")]
    public string? MissionsChampionsKilled { get; set; }

    [JsonPropertyName("Missions_CreepScore")]
    public string? MissionsCreepScore { get; set; }

    [JsonPropertyName("Missions_CreepScoreBy10Minutes")]
    public string? MissionsCreepScoreBy10Minutes { get; set; }

    [JsonPropertyName("Missions_Crepe_DamageDealtSpeedZone")] // What does 'Crepe' mean
    public string? MissionsCrepeDamageDealtSpeedZone { get; set; }

    [JsonPropertyName("Missions_Crepe_SnowballLanded")] // What does 'Crepe' mean
    public string? MissionsCrepeSnowballLanded { get; set; }

    [JsonPropertyName("Missions_Crepe_TakedownsWithInhibBuff")] // What does 'Crepe' mean
    public string? MissionsCrepeTakedownsWithInhibBuff { get; set; }

    [JsonPropertyName("Missions_DamageToChampsWithItems")]
    public string? MissionsDamageToChampsWithItems { get; set; }

    [JsonPropertyName("Missions_DamageToStructures")]
    public string? MissionsDamageToStructures { get; set; }

    [JsonPropertyName("Missions_DestroyPlants")]
    public string? MissionsDestroyPlants { get; set; }

    [JsonPropertyName("Missions_DominationRune")]
    public string? MissionsDominationRune { get; set; }

    [JsonPropertyName("Missions_GoldFromStructuresDestroyed")]
    public string? MissionsGoldFromStructuresDestroyed { get; set; }

    [JsonPropertyName("Missions_GoldFromTurretPlatesTaken")]
    public string? MissionsGoldFromTurretPlatesTaken { get; set; }

    [JsonPropertyName("Missions_GoldPerMinute")]
    public string? MissionsGoldPerMinute { get; set; }

    [JsonPropertyName("Missions_HealingFromLevelObjects")]
    public string? MissionsHealingFromLevelObjects { get; set; }

    [JsonPropertyName("Missions_HexgatesUsed")]
    public string? MissionsHexgatesUsed { get; set; }

    [JsonPropertyName("Missions_ImmobilizeChampions")]
    public string? MissionsImmobilizeChampions { get; set; }

    [JsonPropertyName("Missions_InspirationRune")]
    public string? MissionsInspirationRune { get; set; }

    [JsonPropertyName("Missions_LegendaryItems")]
    public string? MissionsLegendaryItems { get; set; }

    [JsonPropertyName("Missions_MinionsKilled")]
    public string? MissionsMinionsKilled { get; set; }

    [JsonPropertyName("Missions_PeriodicDamage")]
    public string? MissionsPeriodicDamage { get; set; }

    [JsonPropertyName("Missions_PlaceUsefulControlWards")]
    public string? MissionsPlaceUsefulControlWards { get; set; }

    [JsonPropertyName("Missions_PlaceUsefulWards")]
    public string? MissionsPlaceUsefulWards { get; set; }

    [JsonPropertyName("Missions_PorosFed")]
    public string? MissionsPorosFed { get; set; }

    [JsonPropertyName("Missions_PrecisionRune")]
    public string? MissionsPrecisionRune { get; set; }

    [JsonPropertyName("Missions_ResolveRune")]
    public string? MissionsResolveRune { get; set; }

    [JsonPropertyName("Missions_SnowballsHit")]
    public string? MissionsSnowballsHit { get; set; }

    [JsonPropertyName("Missions_SorceryRune")]
    public string? MissionsSorceryRune { get; set; }

    [JsonPropertyName("Missions_TakedownBaronsElderDragons")]
    public string? MissionsTakedownBaronsElderDragons { get; set; }

    [JsonPropertyName("Missions_TakedownDragons")]
    public string? MissionsTakedownDragons { get; set; }

    [JsonPropertyName("Missions_TakedownEpicMonsters")]
    public string? MissionsTakedownEpicMonsters { get; set; }

    [JsonPropertyName("Missions_TakedownEpicMonstersSingleGame")]
    public string? MissionsTakedownEpicMonstersSingleGame { get; set; }

    [JsonPropertyName("Missions_TakedownGold")]
    public string? MissionsTakedownGold { get; set; }

    [JsonPropertyName("Missions_TakedownStructures")]
    public string? MissionsTakedownStructures { get; set; }

    [JsonPropertyName("Missions_TakedownWards")]
    public string? MissionsTakedownWards { get; set; }

    [JsonPropertyName("Missions_TakedownsAfterExhausting")]
    public string? MissionsTakedownsAfterExhausting { get; set; }

    [JsonPropertyName("Missions_TakedownsAfterTeleporting")]
    public string? MissionsTakedownsAfterTeleporting { get; set; }

    [JsonPropertyName("Missions_TakedownsBefore15Min")]
    public string? MissionsTakedownsBefore15Min { get; set; }

    [JsonPropertyName("Missions_TakedownsUnderTurret")]
    public string? MissionsTakedownsUnderTurret { get; set; }

    [JsonPropertyName("Missions_TakedownsWithHelpFromMonsters")]
    public string? MissionsTakedownsWithHelpFromMonsters { get; set; }

    [JsonPropertyName("Missions_TotalGold")]
    public string? MissionsTotalGold { get; set; }

    [JsonPropertyName("Missions_TrueDamageToStructures")]
    public string? MissionsTrueDamageToStructures { get; set; }

    [JsonPropertyName("Missions_TurretPlatesDestroyed")]
    public string? MissionsTurretPlatesDestroyed { get; set; }

    [JsonPropertyName("Missions_TwoChampsKilledWithSameAbility")]
    public string? MissionsTwoChampsKilledWithSameAbility { get; set; }

    [JsonPropertyName("Missions_VoidMitesSummoned")]
    public string? Missions_VoidMitesSummoned { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_5")]
    public string? PlayerAugment5 { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_6")]
    public string? PlayerAugment6 { get; set; }

    [JsonPropertyName("RIOT_ID_GAME_NAME")]
    public string? RiotIdGameName { get; set; }

    [JsonPropertyName("RIOT_ID_TAG_LINE")]
    public string? RiotIdTagLine { get; set; }

    [JsonPropertyName("SUMMONER_ID")]
    public string? SummonerId { get; set; }

    [JsonPropertyName("SUMMONER_SPELL_1")]
    public string? SummonerSpell1 { get; set; }

    [JsonPropertyName("SUMMONER_SPELL_2")]
    public string? SummonerSpell2 { get; set; }

    [JsonPropertyName("SeasonalMissions_TakedownAtakhan")]
    public string? SeasonalMissionsTakedownAtakhan { get; set; }
}

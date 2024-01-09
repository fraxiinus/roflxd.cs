using System.Text.Json.Serialization;

namespace Fraxiinus.Rofl.Extract.Data.Models.Rofl;

/// <summary>
/// Contains all player information
/// </summary>
public class PlayerStats
{
    [JsonPropertyName("ALL_IN_PINGS")]
    public string? AllInPings { get; set; }

    [JsonPropertyName("ASSISTS")]
    public string? Assists { get; set; }

    [JsonPropertyName("ASSIST_ME_PINGS")]
    public string? AssistMePings { get; set; }

    [JsonPropertyName("BAIT_PINGS")]
    public string? BaitPings { get; set; }

    [JsonPropertyName("BARON_KILLS")]
    public string? BaronKills { get; set; }

    /// <summary>
    /// "Barracks" here means "Inhibitors"
    /// </summary>
    [JsonPropertyName("BARRACKS_KILLED")]
    public string? BarracksKilled { get; set; }

    /// <summary>
    /// "Barracks" here means "Inhibitors"
    /// </summary>
    [JsonPropertyName("BARRACKS_TAKEDOWNS")]
    public string? BarracksTakedowns { get; set; }

    [JsonPropertyName("BASIC_PINGS")]
    public string? BasicPings { get; set; }

    [JsonPropertyName("BOUNTY_LEVEL")]
    public string? BountyLevel { get; set; }

    [JsonPropertyName("CHAMPIONS_KILLED")]
    public string? ChampionsKilled { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("CHAMPION_MISSION_STAT_0")]
    public string? ChampionMissionStat0 { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("CHAMPION_MISSION_STAT_1")]
    public string? ChampionMissionStat1 { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("CHAMPION_MISSION_STAT_2")]
    public string? ChampionMissionStat2 { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("CHAMPION_MISSION_STAT_3")]
    public string? ChampionMissionStat3 { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("CHAMPION_TRANSFORM")]
    public string? ChampionTransform { get; set; }

    [JsonPropertyName("COMMAND_PINGS")]
    public string? CommandPings { get; set; }

    [JsonPropertyName("CONSUMABLES_PURCHASED")]
    public string? ConsumablesPurchased { get; set; }

    [JsonPropertyName("DANGER_PINGS")]
    public string? DangerPings { get; set; }

    [JsonPropertyName("DOUBLE_KILLS")]
    public string? DoubleKills { get; set; }

    [JsonPropertyName("DRAGON_KILLS")]
    public string? DragonKills { get; set; }

    [JsonPropertyName("ENEMY_MISSING_PINGS")]
    public string? EnemyMissingPings { get; set; }

    [JsonPropertyName("ENEMY_VISION_PINGS")]
    public string? EnemyVisionPings { get; set; }

    [JsonPropertyName("EXP")]
    public string? Exp { get; set; }

    /// <summary>
    /// Unknown property
    /// </summary>
    [JsonPropertyName("FRIENDLY_DAMPEN_LOST")]
    public string? FriendlyDampenLost { get; set; }

    /// <summary>
    /// "HQ" here means "Nexus"
    /// </summary>
    [JsonPropertyName("FRIENDLY_HQ_LOST")]
    public string? FriendlyHQLost { get; set; }

    [JsonPropertyName("FRIENDLY_TURRET_LOST")]
    public string? FriendlyTurretLost { get; set; }

    [JsonPropertyName("GAME_ENDED_IN_EARLY_SURRENDER")]
    public string? GameEndedInEarlySurrender { get; set; }

    [JsonPropertyName("GAME_ENDED_IN_SURRENDER")]
    public string? GameEndedInSurrender { get; set; }

    [JsonPropertyName("GET_BACK_PINGS")]
    public string? GetBackPings { get; set; }

    [JsonPropertyName("GOLD_EARNED")]
    public string? GoldEarned { get; set; }

    [JsonPropertyName("GOLD_SPENT")]
    public string? GoldSpent { get; set; }

    [JsonPropertyName("HOLD_PINGS")]
    public string? HoldPings { get; set; }

    [JsonPropertyName("HORDE_KILLS")]
    public string? HordeKills { get; set; }

    
    /// <summary>
    /// "HQ" here means "Nexus"
    /// </summary>
    [JsonPropertyName("HQ_KILLED")]
    public string? HQKilled { get; set; }

    /// <summary>
    /// "HQ" here means "Nexus"
    /// </summary>
    [JsonPropertyName("HQ_TAKEDOWNS")]
    public string? HQTakedowns { get; set; }

    [JsonPropertyName("ID")]
    public string? Id { get; set; }

    [JsonPropertyName("INDIVIDUAL_POSITION")]
    public string? IndividualPosition { get; set; }

    [JsonPropertyName("ITEM0")]
    public string? Item0 { get; set; }

    [JsonPropertyName("ITEM1")]
    public string? Item1 { get; set; }

    [JsonPropertyName("ITEM2")]
    public string? Item2 { get; set; }

    [JsonPropertyName("ITEM3")]
    public string? Item3 { get; set; }

    [JsonPropertyName("ITEM4")]
    public string? Item4 { get; set; }

    [JsonPropertyName("ITEM5")]
    public string? Item5 { get; set; }

    [JsonPropertyName("ITEM6")]
    public string? Item6 { get; set; }

    [JsonPropertyName("ITEMS_PURCHASED")]
    public string? ItemsPurchased { get; set; }

    [JsonPropertyName("KEYSTONE_ID")]
    public string? KeystoneId { get; set; }

    [JsonPropertyName("KILLING_SPREES")]
    public string? KillingSprees { get; set; }

    [JsonPropertyName("LARGEST_ABILITY_DAMAGE")]
    public string? LargestAbilityDamage { get; set; }

    [JsonPropertyName("LARGEST_ATTACK_DAMAGE")]
    public string? LargestAttackDamage { get; set; }

    [JsonPropertyName("LARGEST_CRITICAL_STRIKE")]
    public string? LargestCriticalStrike { get; set; }

    [JsonPropertyName("LARGEST_KILLING_SPREE")]
    public string? LargestKillingSpree { get; set; }

    [JsonPropertyName("LARGEST_MULTI_KILL")]
    public string? LargestMultiKill { get; set; }

    [JsonPropertyName("LAST_TAKEDOWN_TIME")]
    public string? LastTakedownTime { get; set; }

    [JsonPropertyName("LEVEL")]
    public string? Level { get; set; }

    [JsonPropertyName("LONGEST_TIME_SPENT_LIVING")]
    public string? LongestTimeSpentLiving { get; set; }

    [JsonPropertyName("MAGIC_DAMAGE_DEALT_PLAYER")]
    public string? MagicDamageDealtPlayer { get; set; }

    [JsonPropertyName("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS")]
    public string? MagicDamageDealtToChampions { get; set; }

    [JsonPropertyName("MAGIC_DAMAGE_TAKEN")]
    public string? MagicDamageTaken { get; set; }

    [JsonPropertyName("MINIONS_KILLED")]
    public string? MinionsKilled { get; set; }

    [JsonPropertyName("MUTED_ALL")]
    public string? MutedAll { get; set; }

    [JsonPropertyName("NAME")]
    public string? Name { get; set; }

    [JsonPropertyName("NEED_VISION_PINGS")]
    public string? NeedVisionPings { get; set; }

    [JsonPropertyName("NEUTRAL_MINIONS_KILLED")]
    public string? NeutralMinionsKilled { get; set; }

    [JsonPropertyName("NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE")]
    public string? NeutralMinionsKilledEnemyJungle { get; set; }

    [JsonPropertyName("NEUTRAL_MINIONS_KILLED_YOUR_JUNGLE")]
    public string? NeutralMinionsKilledYourJungle { get; set; }

    [JsonPropertyName("NODE_CAPTURE")]
    public string? NodeCapture { get; set; }

    [JsonPropertyName("NODE_CAPTURE_ASSIST")]
    public string? NodeCaptureAssist { get; set; }

    [JsonPropertyName("NODE_NEUTRALIZE")]
    public string? NodeNeutralize { get; set; }

    [JsonPropertyName("NODE_NEUTRALIZE_ASSIST")]
    public string? NodeNeutralizeAssist { get; set; }

    [JsonPropertyName("NUM_DEATHS")]
    public string? NumDeaths { get; set; }

    [JsonPropertyName("OBJECTIVES_STOLEN")]
    public string? ObjectivesStolen { get; set; }

    [JsonPropertyName("OBJECTIVES_STOLEN_ASSISTS")]
    public string? ObjectivesStolenAssists { get; set; }

    [JsonPropertyName("ON_MY_WAY_PINGS")]
    public string? OnMyWayPings { get; set; }

    [JsonPropertyName("PENTA_KILLS")]
    public string? PentaKills { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK0")]
    public string? Perk0 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK0_VAR1")]
    public string? Perk0Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK0_VAR2")]
    public string? Perk0Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK0_VAR3")]
    public string? Perk0Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK1")]
    public string? Perk1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK1_VAR1")]
    public string? Perk1Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK1_VAR2")]
    public string? Perk1Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK1_VAR3")]
    public string? Perk1Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK2")]
    public string? Perk2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK2_VAR1")]
    public string? Perk2Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK2_VAR2")]
    public string? Perk2Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK2_VAR3")]
    public string? Perk2Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK3")]
    public string? Perk3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK3_VAR1")]
    public string? Perk3Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK3_VAR2")]
    public string? Perk3Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK3_VAR3")]
    public string? Perk3Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK4")]
    public string? Perk4 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK4_VAR1")]
    public string? Perk4Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK4_VAR2")]
    public string? Perk4Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK4_VAR3")]
    public string? Perk4Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK5")]
    public string? Perk5 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK5_VAR1")]
    public string? Perk5Var1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK5_VAR2")]
    public string? Perk5Var2 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK5_VAR3")]
    public string? Perk5Var3 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK_PRIMARY_STYLE")]
    public string? PerkPrimaryStyle { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("PERK_SUB_STYLE")]
    public string? PerkSubStyle { get; set; }

    [JsonPropertyName("PHYSICAL_DAMAGE_DEALT_PLAYER")]
    public string? PhysicalDamageDealtPlayer { get; set; }

    [JsonPropertyName("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS")]
    public string? PhysicalDamageDealtToChampions { get; set; }

    [JsonPropertyName("PHYSICAL_DAMAGE_TAKEN")]
    public string? PhysicalDamageTaken { get; set; }

    [JsonPropertyName("PING")]
    public string? Ping { get; set; }

    [JsonPropertyName("PLAYERS_I_MUTED")]
    public string? PlayersIMuted { get; set; }

    [JsonPropertyName("PLAYERS_THAT_MUTED_ME")]
    public string? PlayersThatMutedMe { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_1")]
    public string? PlayerAugment1 { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_2")]
    public string? PlayerAugment2 { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_3")]
    public string? PlayerAugment3 { get; set; }

    [JsonPropertyName("PLAYER_AUGMENT_4")]
    public string? PlayerAugment4 { get; set; }

    [JsonPropertyName("PLAYER_POSITION")]
    public string? PlayerPosition { get; set; }

    [JsonPropertyName("PLAYER_ROLE")]
    public string? PlayerRole { get; set; }

    [JsonPropertyName("PLAYER_SCORE_0")]
    public string? PlayerScore0 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_1")]
    public string? PlayerScore1 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_10")]
    public string? PlayerScore10 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_11")]
    public string? PlayerScore11 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_2")]
    public string? PlayerScore2 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_3")]
    public string? PlayerScore3 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_4")]
    public string? PlayerScore4 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_5")]
    public string? PlayerScore5 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_6")]
    public string? PlayerScore6 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_7")]
    public string? PlayerScore7 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_8")]
    public string? PlayerScore8 { get; set; }

    [JsonPropertyName("PLAYER_SCORE_9")]
    public string? PlayerScore9 { get; set; }

    [JsonPropertyName("PLAYER_SUBTEAM")]
    public string? PlayerSubteam { get; set; }

    [JsonPropertyName("PLAYER_SUBTEAM_PLACEMENT")]
    public string? PlayerSubteamPlacement { get; set; }

    [JsonPropertyName("PUSH_PINGS")]
    public string? PushPings { get; set; }

    /// <summary>
    /// Player Universally Unique IDentifiers. The value is unencrypted.
    /// </summary>
    [JsonPropertyName("PUUID")]
    public string? PUUID { get; set; }

    [JsonPropertyName("QUADRA_KILLS")]
    public string? QuadraKills { get; set; }

    [JsonPropertyName("RETREAT_PINGS")]
    public string? RetreatPings { get; set; }

    [JsonPropertyName("RIFT_HERALD_KILLS")]
    public string? RiftHeraldKills { get; set; }

    [JsonPropertyName("SIGHT_WARDS_BOUGHT_IN_GAME")]
    public string? SightWardsBoughtInGame { get; set; }

    /// <summary>
    /// "Skin" here means "Champion"
    /// </summary>
    [JsonPropertyName("SKIN")]
    public string? Skin { get; set; }

    [JsonPropertyName("SPELL1_CAST")]
    public string? Spell1Cast { get; set; }

    [JsonPropertyName("SPELL2_CAST")]
    public string? Spell2Cast { get; set; }

    [JsonPropertyName("SPELL3_CAST")]
    public string? Spell3Cast { get; set; }

    [JsonPropertyName("SPELL4_CAST")]
    public string? Spell4Cast { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("STAT_PERK_0")]
    public string? StatPerk0 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("STAT_PERK_1")]
    public string? StatPerk1 { get; set; }

    /// <summary>
    /// "Perk" here means "Rune"
    /// </summary>
    [JsonPropertyName("STAT_PERK_2")]
    public string? StatPerk2 { get; set; }

    [JsonPropertyName("SUMMON_SPELL1_CAST")]
    public string? SummonSpell1Cast { get; set; }

    [JsonPropertyName("SUMMON_SPELL2_CAST")]
    public string? SummonSpell2Cast { get; set; }

    [JsonPropertyName("TEAM")]
    public string? Team { get; set; }

    [JsonPropertyName("TEAM_EARLY_SURRENDERED")]
    public string? TeamEarlySurrendered { get; set; }

    [JsonPropertyName("TEAM_OBJECTIVE")]
    public string? TeamObjective { get; set; }

    [JsonPropertyName("TEAM_POSITION")]
    public string? TeamPosition { get; set; }

    [JsonPropertyName("TIME_CCING_OTHERS")]
    public string? TimeCCingOthers { get; set; }

    [JsonPropertyName("TIME_OF_FROM_LAST_DISCONNECT")]
    public string? TimeOfFromLastDisconnect { get; set; }

    [JsonPropertyName("TIME_PLAYED")]
    public string? TimePlayed { get; set; }

    [JsonPropertyName("TIME_SPENT_DISCONNECTED")]
    public string? TimeSpentDisconnected { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_DEALT")]
    public string? TotalDamageDealt { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_DEALT_TO_BUILDINGS")]
    public string? TotalDamageDealtToBuildings { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS")]
    public string? TotalDamageDealtToChampions { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_DEALT_TO_OBJECTIVES")]
    public string? TotalDamageDealtToObjectives { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_DEALT_TO_TURRETS")]
    public string? TotalDamageDealtToTurrets { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_SELF_MITIGATED")]
    public string? TotalDamageSelfMitigated { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES")]
    public string? TotalDamageShieldedOnTeammates { get; set; }

    [JsonPropertyName("TOTAL_DAMAGE_TAKEN")]
    public string? TotalDamageTaken { get; set; }

    [JsonPropertyName("TOTAL_HEAL")]
    public string? TotalHeal { get; set; }

    [JsonPropertyName("TOTAL_HEAL_ON_TEAMMATES")]
    public string? TotalHealOnTeammates { get; set; }

    [JsonPropertyName("TOTAL_TIME_CROWD_CONTROL_DEALT")]
    public string? TotalTimeCrowdControlDealt { get; set; }

    [JsonPropertyName("TOTAL_TIME_CROWD_CONTROL_DEALT_TO_CHAMPIONS")]
    public string? TotalTimeCrowdControlDealtToChampions { get; set; }

    [JsonPropertyName("TOTAL_TIME_SPENT_DEAD")]
    public string? TotalTimeSpentDead { get; set; }

    [JsonPropertyName("TOTAL_UNITS_HEALED")]
    public string? TotalUnitsHealed { get; set; }

    [JsonPropertyName("TRIPLE_KILLS")]
    public string? TripleKills { get; set; }

    [JsonPropertyName("TRUE_DAMAGE_DEALT_PLAYER")]
    public string? TrueDamageDealtPlayer { get; set; }

    [JsonPropertyName("TRUE_DAMAGE_DEALT_TO_CHAMPIONS")]
    public string? TrueDamageDealtToChampions { get; set; }

    [JsonPropertyName("TRUE_DAMAGE_TAKEN")]
    public string? TrueDamageTaken { get; set; }

    [JsonPropertyName("TURRETS_KILLED")]
    public string? TurretsKilled { get; set; }

    [JsonPropertyName("TURRET_TAKEDOWNS")]
    public string? TurretTakedowns { get; set; }

    /// <summary>
    /// Sorry, this is a field required for ReplayBook to function. Unique ID to match
    /// </summary>
    [JsonIgnore]
    public string? UniqueId { get; set; }

    /// <summary>
    /// "Unreal kills" is a 6 kill killing spree
    /// </summary>
    [JsonPropertyName("UNREAL_KILLS")]
    public string? UnrealKills { get; set; }

    [JsonPropertyName("VICTORY_POINT_TOTAL")]
    public string? VictoryPointTotal { get; set; }

    [JsonPropertyName("VISION_CLEARED_PINGS")]
    public string? VisionClearedPings { get; set; }

    [JsonPropertyName("VISION_SCORE")]
    public string? VisionScore { get; set; }

    [JsonPropertyName("VISION_WARDS_BOUGHT_IN_GAME")]
    public string? VisionWardsBoughtInGame { get; set; }

    [JsonPropertyName("WARD_KILLED")]
    public string? WardKilled { get; set; }

    [JsonPropertyName("WARD_PLACED")]
    public string? WardPlaced { get; set; }

    [JsonPropertyName("WARD_PLACED_DETECTOR")]
    public string? WardPlacedDetector { get; set; }

    [JsonPropertyName("WAS_AFK")]
    public string? WasAfk { get; set; }

    [JsonPropertyName("WAS_AFK_AFTER_FAILED_SURRENDER")]
    public string? WasAfkAfterFailedSurrender { get; set; }

    [JsonPropertyName("WAS_EARLY_SURRENDER_ACCOMPLICE")]
    public string? WasEarlySurrenderAccomplice { get; set; }

    [JsonPropertyName("WAS_LEAVER")]
    public string? WasLeaver { get; set; }

    [JsonPropertyName("WAS_SURRENDER_DUE_TO_AFK")]
    public string? WasSurrenderDueToAfk { get; set; }

    [JsonPropertyName("WIN")]
    public string? Win { get; set; }
}

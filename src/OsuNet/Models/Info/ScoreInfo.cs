using OsuNet.Enums;
using System.Text.Json.Serialization;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about a user in a match.
    /// </summary>
    public record ScoreInfo(
        /// <summary>
        /// Player slot number.
        /// </summary>
        [property: JsonPropertyName("slot")] byte Slot,

        /// <summary>
        /// The team this player is on.
        /// </summary>
        [property: JsonPropertyName("team")] Team Team,

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [property: JsonPropertyName("user_id")] ulong UserId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [property: JsonPropertyName("score")] ulong TotalScore,

        /// <summary>
        /// The number of maximum combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("maxcombo")] ulong MaxCombo,

        /// <summary>
        /// The rank the player has received. (Here not used)
        /// </summary>
        [property: JsonPropertyName("rank")] string? Rank,

        /// <summary>
        /// The number of 50 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count50")] ulong Count50,

        /// <summary>
        /// The number of 100 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count100")] ulong Count100,

        /// <summary>
        /// The number of 300 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count300")] ulong Count300,

        /// <summary>
        /// The number of misses that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countmiss")] ulong CountMiss,

        /// <summary>
        /// The number of perfect combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countgeki")] ulong CountGeki,

        /// <summary>
        /// The number of good combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countkatu")] ulong CountKatu,

        /// <summary>
        /// True if score is perfect, false otherwise.
        /// </summary>
        [property: JsonPropertyName("perfect")] bool IsPerfect,

        /// <summary>
        /// True if the player hasn't lost all their lives, otherwise false.
        /// </summary>
        [property: JsonPropertyName("pass")] bool Pass,

        /// <summary>
        /// Mods used by this player.
        /// </summary>
        [property: JsonPropertyName("enabled_mods")] Mods? EnabledMods
    );
}
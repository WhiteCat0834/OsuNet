using OsuNet.Enums;
using System.Text.Json.Serialization;

namespace OsuNet.Models {
    /// <summary>
    /// Gets the user's ten most recent plays over the last 24 hours.
    /// </summary>
    public record UserRecent(
        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [property: JsonPropertyName("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Unique score ID.
        /// </summary>
        [property: JsonPropertyName("score_id")] ulong? ScoreId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [property: JsonPropertyName("score")] ulong TotalScore,

        /// <summary>
        /// The number of maximum combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("maxcombo")] ulong MaxCombo,

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
        /// The number of good combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countkatu")] ulong CountKatu,

        /// <summary>
        /// The number of perfect combos that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countgeki")] ulong CountGeki,

        /// <summary>
        /// True if score is perfect, false otherwise.
        /// </summary>
        [property: JsonPropertyName("perfect")] bool IsPerfect,

        /// <summary>
        /// Mods used by this player.
        /// </summary>
        [property: JsonPropertyName("enabled_mods")] Mods EnabledMods,

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [property: JsonPropertyName("user_id")] ulong UserId,

        /// <summary>
        /// Date and time the record was set.
        /// </summary>
        [property: JsonPropertyName("date")] DateTime DateTime,

        /// <summary>
        /// The rank this player has received.
        /// </summary>
        [property: JsonPropertyName("rank")] string Rank
    );
}
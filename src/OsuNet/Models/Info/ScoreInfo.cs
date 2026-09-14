using Newtonsoft.Json;
using OsuNet.Enums;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about a user in a match.
    /// </summary>
    public record ScoreInfo(
        /// <summary>
        /// Player slot number.
        /// </summary>
        [JsonProperty("slot")] byte Slot,

        /// <summary>
        /// The team this player is on.
        /// </summary>
        [JsonProperty("team")] Team Team,

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [JsonProperty("user_id")] ulong UserId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [JsonProperty("score")] ulong TotalScore,

        /// <summary>
        /// The number of maximum combos that the player has hit.
        /// </summary>
        [JsonProperty("maxcombo")] ulong MaxCombo,

        /// <summary>
        /// The rank the player has received. (Here not used)
        /// </summary>
        [JsonProperty("rank")] string? Rank,

        /// <summary>
        /// The number of 50 points that the player has hit.
        /// </summary>
        [JsonProperty("count50")] ulong Count50,

        /// <summary>
        /// The number of 100 points that the player has hit.
        /// </summary>
        [JsonProperty("count100")] ulong Count100,

        /// <summary>
        /// The number of 300 points that the player has hit.
        /// </summary>
        [JsonProperty("count300")] ulong Count300,

        /// <summary>
        /// The number of misses that the player has hit.
        /// </summary>
        [JsonProperty("countmiss")] ulong CountMiss,

        /// <summary>
        /// The number of perfect combos that the player has hit.
        /// </summary>
        [JsonProperty("countgeki")] ulong CountGeki,

        /// <summary>
        /// The number of good combos that the player has hit.
        /// </summary>
        [JsonProperty("countkatu")] ulong CountKatu,

        /// <summary>
        /// True if score is perfect, false otherwise.
        /// </summary>
        [JsonProperty("perfect")] bool IsPerfect,

        /// <summary>
        /// True if the player hasn't lost all their lives, otherwise false.
        /// </summary>
        [JsonProperty("pass")] bool Pass,

        /// <summary>
        /// Mods used by this player.
        /// </summary>
        [JsonProperty("enabled_mods")] Mods? EnabledMods
    );
}
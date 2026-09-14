using Newtonsoft.Json;
using OsuNet.Enums;

namespace OsuNet.Models {
    /// <summary>
    /// Get the top scores for the specified user.
    /// </summary>
    public record UserBest(
        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [JsonProperty("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Unique score ID.
        /// </summary>
        [JsonProperty("score_id")] ulong ScoreId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [JsonProperty("score")] ulong TotalScore,

        /// <summary>
        /// The number of maximum combos that the player has hit.
        /// </summary>
        [JsonProperty("maxcombo")] ulong MaxCombo,

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
        /// The number of good combos that the player has hit.
        /// </summary>
        [JsonProperty("countkatu")] ulong CountKatu,

        /// <summary>
        /// The number of perfect combos that the player has hit.
        /// </summary>
        [JsonProperty("countgeki")] ulong CountGeki,

        /// <summary>
        /// True if score is perfect, false otherwise.
        /// </summary>
        [JsonProperty("perfect")] bool IsPerfect,

        /// <summary>
        /// Mods used by this player.
        /// </summary>
        [JsonProperty("enabled_mods")] Mods? EnabledMods,

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [JsonProperty("user_id")] ulong UserId,

        /// <summary>
        /// Date and time the record was set.
        /// </summary>
        [JsonProperty("date")] DateTime DateTime,

        /// <summary>
        /// The rank the player has received.
        /// </summary>
        [JsonProperty("rank")] string Rank,

        /// <summary>
        /// The number of PP that the player has hit.
        /// </summary>
        [JsonProperty("pp")] float PP,

        /// <summary>
        /// True if you can watch the replay, otherwise false.
        /// </summary>
        [JsonProperty("replay_available")] bool ReplayAvailable
    );
}
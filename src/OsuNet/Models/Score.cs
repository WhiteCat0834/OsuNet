using Newtonsoft.Json;
using OsuNet.Enums;

namespace OsuNet.Models {
    /// <summary>
    /// Represents a score record from the osu! API, containing player performance data for a specific beatmap.
    /// </summary>
    public record Score(
        /// <summary>
        /// Unique score ID.
        /// </summary>
        [JsonProperty("score_id")] ulong ScoreId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [JsonProperty("score")] int TotalScore,

        /// <summary>
        /// Nickname of this player.
        /// </summary>
        [JsonProperty("username")] string Username,

        /// <summary>
        /// The number of 300 points that the player has hit.
        /// </summary>
        [JsonProperty("count300")] ushort Count300,

        /// <summary>
        /// The number of 100 points that the player has hit.
        /// </summary>
        [JsonProperty("count100")] ushort Count100,

        /// <summary>
        /// The number of 50 points that the player has hit.
        /// </summary>
        [JsonProperty("count50")] ushort Count50,

        /// <summary>
        /// The number of misses that the player has hit.
        /// </summary>
        [JsonProperty("countmiss")] ushort CountMiss,

        /// <summary>
        /// The maximum combo that the player has hit.
        /// </summary>
        [JsonProperty("maxcombo")] ushort MaxCombo,

        /// <summary>
        /// The number of katu hits.
        /// </summary>
        [JsonProperty("countkatu")] ushort CountKatu,

        /// <summary>
        /// The number of geki hits.
        /// </summary>
        [JsonProperty("countgeki")] ushort CountGeki,

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
        /// The number of PP that the player has hit. Can be null for older scores or failed attempts.
        /// </summary>
        [JsonProperty("pp")] float? PP,

        /// <summary>
        /// True if you can watch the replay, otherwise false.
        /// </summary>
        [JsonProperty("replay_available")] bool ReplayAvailable
    );
}
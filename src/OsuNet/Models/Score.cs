using OsuNet.Enums;
using System.Text.Json.Serialization;

namespace OsuNet.Models {
    /// <summary>
    /// Represents a score record from the osu! API, containing player performance data for a specific beatmap.
    /// </summary>
    public record Score(
        /// <summary>
        /// Unique score ID.
        /// </summary>
        [property: JsonPropertyName("score_id")] ulong ScoreId,

        /// <summary>
        /// The number of points scored by this player.
        /// </summary>
        [property: JsonPropertyName("score")] int TotalScore,

        /// <summary>
        /// Nickname of this player.
        /// </summary>
        [property: JsonPropertyName("username")] string Username,

        /// <summary>
        /// The number of 300 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count300")] ushort Count300,

        /// <summary>
        /// The number of 100 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count100")] ushort Count100,

        /// <summary>
        /// The number of 50 points that the player has hit.
        /// </summary>
        [property: JsonPropertyName("count50")] ushort Count50,

        /// <summary>
        /// The number of misses that the player has hit.
        /// </summary>
        [property: JsonPropertyName("countmiss")] ushort CountMiss,

        /// <summary>
        /// The maximum combo that the player has hit.
        /// </summary>
        [property: JsonPropertyName("maxcombo")] ushort MaxCombo,

        /// <summary>
        /// The number of katu hits.
        /// </summary>
        [property: JsonPropertyName("countkatu")] ushort CountKatu,

        /// <summary>
        /// The number of geki hits.
        /// </summary>
        [property: JsonPropertyName("countgeki")] ushort CountGeki,

        /// <summary>
        /// True if score is perfect, false otherwise.
        /// </summary>
        [property: JsonPropertyName("perfect")] bool IsPerfect,

        /// <summary>
        /// Mods used by this player.
        /// </summary>
        [property: JsonPropertyName("enabled_mods")] Mods? EnabledMods,

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [property: JsonPropertyName("user_id")] ulong UserId,

        /// <summary>
        /// Date and time the record was set.
        /// </summary>
        [property: JsonPropertyName("date")] DateTime DateTime,

        /// <summary>
        /// The rank the player has received.
        /// </summary>
        [property: JsonPropertyName("rank")] string Rank,

        /// <summary>
        /// The number of PP that the player has hit. Can be null for older scores or failed attempts.
        /// </summary>
        [property: JsonPropertyName("pp")] float? PP,

        /// <summary>
        /// True if you can watch the replay, otherwise false.
        /// </summary>
        [property: JsonPropertyName("replay_available")] bool ReplayAvailable
    );
}
using OsuNet.Models.Info;
using System.Text.Json.Serialization;

namespace OsuNet.Models {
    /// <summary>
    /// Represents user information from the osu! API, containing player statistics and profile data.
    /// </summary>
    public record User(
        /// <summary>
        /// Unique user ID.
        /// </summary>
        [property: JsonPropertyName("user_id")] ulong UserId,

        /// <summary>
        /// Nickname of this player.
        /// </summary>
        [property: JsonPropertyName("username")] string Username,

        /// <summary>
        /// Date and time the account was created.
        /// </summary>
        [property: JsonPropertyName("join_date")] DateTime JoinDate,

        /// <summary>
        /// The number of 300 points that the player has accumulated over the entire time.
        /// </summary>
        [property: JsonPropertyName("count300")] ulong Count300,

        /// <summary>
        /// The number of 100 points that the player has accumulated over the entire time.
        /// </summary>
        [property: JsonPropertyName("count100")] ulong Count100,

        /// <summary>
        /// The number of 50 points that the player has accumulated over the entire time.
        /// </summary>
        [property: JsonPropertyName("count50")] ulong Count50,

        /// <summary>
        /// Only counts ranked, approved, and loved beatmaps.
        /// </summary>
        [property: JsonPropertyName("playcount")] ulong PlayCount,

        /// <summary>
        /// Counts the best individual score on each ranked, approved, and loved beatmaps.
        /// </summary>
        [property: JsonPropertyName("ranked_score")] ulong RankedScore,

        /// <summary>
        /// Counts every score on ranked, approved, and loved beatmaps.
        /// </summary>
        [property: JsonPropertyName("total_score")] ulong TotalScore,

        /// <summary>
        /// Place in the world top.
        /// </summary>
        [property: JsonPropertyName("pp_rank")] ulong PPRank,

        /// <summary>
        /// This player's level.
        /// </summary>
        [property: JsonPropertyName("level")] float Level,

        /// <summary>
        /// The number of PP that the player has accumulated over the entire time.
        /// </summary>
        [property: JsonPropertyName("pp_raw")] float PPRaw,

        /// <summary>
        /// The accuracy of this player.
        /// </summary>
        [property: JsonPropertyName("accuracy")] float Accuracy,

        /// <summary>
        /// Count for SS ranks on maps.
        /// </summary>
        [property: JsonPropertyName("count_rank_ss")] ulong CountRankSS,

        /// <summary>
        /// Count for SSH ranks on maps.
        /// </summary>
        [property: JsonPropertyName("count_rank_ssh")] ulong CountRankSSH,

        /// <summary>
        /// Count for S ranks on maps.
        /// </summary>
        [property: JsonPropertyName("count_rank_s")] ulong CountRankS,

        /// <summary>
        /// Count for SH ranks on maps.
        /// </summary>
        [property: JsonPropertyName("count_rank_sh")] ulong CountRankSH,

        /// <summary>
        /// Count for A ranks on maps.
        /// </summary>
        [property: JsonPropertyName("count_rank_a")] ulong CountRankA,

        /// <summary>
        /// Place in the top of the country.
        /// </summary>
        [property: JsonPropertyName("country")] string Country,

        /// <summary>
        /// The number of seconds played.
        /// </summary>
        [property: JsonPropertyName("total_seconds_played")] ulong TotalSecondsPlayed,

        /// <summary>
        /// The user's rank in the country.
        /// </summary>
        [property: JsonPropertyName("pp_country_rank")] ulong PPCountryRank,

        /// <summary>
        /// Contains events for this user.
        /// </summary>
        [property: JsonPropertyName("events")] IReadOnlyList<EventInfo> Events
    );
}
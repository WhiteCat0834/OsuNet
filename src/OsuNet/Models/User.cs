using Newtonsoft.Json;
using OsuNet.Models.Info;

namespace OsuNet.Models {
    /// <summary>
    /// Represents user information from the osu! API, containing player statistics and profile data.
    /// </summary>
    public record User(
        /// <summary>
        /// Unique user ID.
        /// </summary>
        [JsonProperty("user_id")] ulong UserId,

        /// <summary>
        /// Nickname of this player.
        /// </summary>
        [JsonProperty("username")] string Username,

        /// <summary>
        /// Date and time the account was created.
        /// </summary>
        [JsonProperty("join_date")] DateTime JoinDate,

        /// <summary>
        /// The number of 300 points that the player has accumulated over the entire time.
        /// </summary>
        [JsonProperty("count300")] ulong Count300,

        /// <summary>
        /// The number of 100 points that the player has accumulated over the entire time.
        /// </summary>
        [JsonProperty("count100")] ulong Count100,

        /// <summary>
        /// The number of 50 points that the player has accumulated over the entire time.
        /// </summary>
        [JsonProperty("count50")] ulong Count50,

        /// <summary>
        /// Only counts ranked, approved, and loved beatmaps.
        /// </summary>
        [JsonProperty("playcount")] ulong PlayCount,

        /// <summary>
        /// Counts the best individual score on each ranked, approved, and loved beatmaps.
        /// </summary>
        [JsonProperty("ranked_score")] ulong RankedScore,

        /// <summary>
        /// Counts every score on ranked, approved, and loved beatmaps.
        /// </summary>
        [JsonProperty("total_score")] ulong TotalScore,

        /// <summary>
        /// Place in the world top.
        /// </summary>
        [JsonProperty("pp_rank")] ulong PPRank,

        /// <summary>
        /// This player's level.
        /// </summary>
        [JsonProperty("level")] float Level,

        /// <summary>
        /// The number of PP that the player has accumulated over the entire time.
        /// </summary>
        [JsonProperty("pp_raw")] float PPRaw,

        /// <summary>
        /// The accuracy of this player.
        /// </summary>
        [JsonProperty("accuracy")] float Accuracy,

        /// <summary>
        /// Count for SS ranks on maps.
        /// </summary>
        [JsonProperty("count_rank_ss")] ulong CountRankSS,

        /// <summary>
        /// Count for SSH ranks on maps.
        /// </summary>
        [JsonProperty("count_rank_ssh")] ulong CountRankSSH,

        /// <summary>
        /// Count for S ranks on maps.
        /// </summary>
        [JsonProperty("count_rank_s")] ulong CountRankS,

        /// <summary>
        /// Count for SH ranks on maps.
        /// </summary>
        [JsonProperty("count_rank_sh")] ulong CountRankSH,

        /// <summary>
        /// Count for A ranks on maps.
        /// </summary>
        [JsonProperty("count_rank_a")] ulong CountRankA,

        /// <summary>
        /// Place in the top of the country.
        /// </summary>
        [JsonProperty("country")] string Country,

        /// <summary>
        /// The number of seconds played.
        /// </summary>
        [JsonProperty("total_seconds_played")] ulong TotalSecondsPlayed,

        /// <summary>
        /// The user's rank in the country.
        /// </summary>
        [JsonProperty("pp_country_rank")] ulong PPCountryRank,

        /// <summary>
        /// Contains events for this user.
        /// </summary>
        [JsonProperty("events")] IReadOnlyList<EventInfo> Events
    );
}
using Newtonsoft.Json;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about the match.
    /// </summary>
    public class MatchInfo {
        /// <summary>
        /// Allows explicit casting of a numeric value (typically <c>0</c>) to a <see cref="MatchInfo"/> object.
        /// </summary>
        /// <param name="v">The numeric value returned by the osu! API.</param>
        /// <returns>A new, empty <see cref="MatchInfo"/> instance.</returns>
        /// <remarks>
        /// This operator is specifically designed to handle edge cases in the osu! API response. 
        /// When a multiplayer match does not exist, is invalid, or has no data, the API returns 
        /// the integer <c>0</c> instead of a JSON object. This explicit conversion allows the JSON 
        /// deserializer to gracefully convert that <c>0</c> into an empty <see cref="MatchInfo"/> 
        /// instance rather than throwing a deserialization exception.
        /// </remarks>
        public static explicit operator MatchInfo(long v) => new MatchInfo();

        /// <summary>
        /// The unique ID of the match.
        /// </summary>
        [JsonProperty("match_id")]
        public ulong MatchId { get; set; }

        /// <summary>
        /// Lobby Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Date and time the lobby was created.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Date and time the lobby was deleted.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }
    }
}

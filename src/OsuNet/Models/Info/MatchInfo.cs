using System.Text.Json.Serialization;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about the match.
    /// </summary>
    public record MatchInfo(
        /// <summary>
        /// The unique ID of the match.
        /// </summary>
        [property: JsonPropertyName("match_id")] ulong MatchId,

        /// <summary>
        /// Lobby Name.
        /// </summary>
        [property: JsonPropertyName("name")] string? Name,

        /// <summary>
        /// Date and time the lobby was created.
        /// </summary>
        [property: JsonPropertyName("start_time")] DateTime StartTime,

        /// <summary>
        /// Date and time the lobby was deleted.
        /// </summary>
        [property: JsonPropertyName("end_time")] DateTime? EndTime
    ) {
        /// <summary>
        /// Allows explicit casting of a numeric value (typically <c>0</c>) to a <see cref="MatchInfo"/> object.
        /// </summary>
        /// <param name="v">The numeric value returned by the osu! API.</param>
        /// <returns>A new, empty <see cref="MatchInfo"/> instance.</returns>
        public static explicit operator MatchInfo(long v) => new MatchInfo(0, null, default, null);
    }
}
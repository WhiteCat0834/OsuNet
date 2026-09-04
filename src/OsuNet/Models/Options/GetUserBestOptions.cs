using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving a user's best performance scores.
    /// </summary>
    public class GetUserBestOptions {
        /// <summary>
        /// User is a required option. The username or ID to query.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The game mode to retrieve top scores for.
        /// </summary>
        public BeatmapMode? Mode { get; set; } = 0;

        /// <summary>
        /// The maximum number of results to return.
        /// </summary>
        public int? Limit { get; set; } = 10;

        /// <summary>
        /// Specifies whether the <see cref="User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string Type { get; set; }
    }
}
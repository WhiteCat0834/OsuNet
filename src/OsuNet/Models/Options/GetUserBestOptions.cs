using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving a user's best performance scores.
    /// </summary>
    public record GetUserBestOptions {
        /// <summary>
        /// User is a required option. The username or ID to query.
        /// </summary>
        public string User { get; init; }

        /// <summary>
        /// The game mode to retrieve top scores for.
        /// </summary>
        public BeatmapMode? Mode { get; init; } = 0;

        /// <summary>
        /// The maximum number of results to return.
        /// </summary>
        public int? Limit { get; init; } = 10;

        /// <summary>
        /// Specifies whether the <see cref="Models.User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string? Type { get; init; }
    }
}
using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving general user information.
    /// </summary>
    public record GetUserOptions {
        /// <summary>
        /// User is a required option. The username or ID to query.
        /// </summary>
        public string User { get; init; }

        /// <summary>
        /// The game mode to retrieve user statistics for.
        /// </summary>
        public BeatmapMode? Mode { get; init; } = 0;

        /// <summary>
        /// Specifies whether the <see cref="Models.User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string? Type { get; init; }

        /// <summary>
        /// The number of days to look back for user events.
        /// </summary>
        public byte? EventDays { get; init; } = 1;
    }
}
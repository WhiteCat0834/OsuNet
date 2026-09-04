using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving general user information.
    /// </summary>
    public class GetUserOptions {
        /// <summary>
        /// User is a required option. The username or ID to query.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The game mode to retrieve user statistics for.
        /// </summary>
        public BeatmapMode? Mode { get; set; } = 0;

        /// <summary>
        /// Specifies whether the <see cref="User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The number of days to look back for user events.
        /// </summary>
        public byte? EventDays { get; set; } = 1;
    }
}
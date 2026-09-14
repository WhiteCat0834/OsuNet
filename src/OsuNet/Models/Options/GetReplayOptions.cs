using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving a specific replay file.
    /// </summary>
    public class GetReplayOptions {
        /// <summary>
        /// BeatmapId is a required option.<br/><b>Note:</b> This must be the specific Beatmap ID, NOT the BeatmapSetId.
        /// </summary>
        public ulong BeatmapId { get; set; }

        /// <summary>
        /// User is a required option. The username or ID associated with the score.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The game mode of the replay.
        /// </summary>
        public BeatmapMode? Mode { get; set; }

        /// <summary>
        /// Optional. The specific score ID to retrieve the replay for (takes precedence if provided).
        /// </summary>
        public string ScoreId { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Optional. Filters by specific mods applied to the score.
        /// </summary>
        public Mods? Mods { get; set; }
    }
}
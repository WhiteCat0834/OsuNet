using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving high scores on a specific beatmap.
    /// </summary>
    public class GetScoresOptions {
        /// <summary>
        /// BeatmapId is a required option.<br/><b>Note:</b> This must be the specific Beatmap ID, NOT the BeatmapSetId.
        /// </summary>
        public ulong? BeatmapId { get; set; }

        /// <summary>
        /// Optional. Filters scores to a specific username or ID.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The game mode to retrieve scores for.
        /// </summary>
        public BeatmapMode? Mode { get; set; } = 0;

        /// <summary>
        /// Optional. Filters scores by specific mods.
        /// </summary>
        public Mods? Mods { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The maximum number of results to return.
        /// </summary>
        public int? Limit { get; set; } = 50;
    }
}
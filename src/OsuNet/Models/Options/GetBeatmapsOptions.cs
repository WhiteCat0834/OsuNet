using OsuNet.Enums;

namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving beatmap information from the API.
    /// </summary>
    public record GetBeatmapsOptions {
        /// <summary>
        /// Return beatmaps ranked or approved since this date.
        /// </summary>
        public DateTime? Since { get; init; }

        /// <summary>
        /// The unique ID of the beatmap set to query.
        /// </summary>
        public ulong? BeatmapSetId { get; init; }

        /// <summary>
        /// The unique ID of a specific beatmap difficulty to query.
        /// </summary>
        public ulong? BeatmapId { get; init; }

        /// <summary>
        /// Beatmap creator. The username or ID of the user who mapped it.
        /// </summary>
        public string? User { get; init; }

        /// <summary>
        /// Specifies whether the <see cref="User"/> is a username or an ID (e.g., "id" or "string").
        /// </summary>
        public string? Type { get; init; }

        /// <summary>
        /// The game mode to filter beatmaps by.
        /// </summary>
        public BeatmapMode? Mode { get; init; }

        /// <summary>
        /// Whether to include converted beatmaps (auto-generated difficulties for other modes).
        /// </summary>
        public bool? ConvertedBeatmaps { get; init; }

        /// <summary>
        /// The MD5 hash of the beatmap file (.osu). Useful for querying a specific file version.
        /// </summary>
        public string? Hash { get; init; }

        /// <summary>
        /// The maximum number of results to return.
        /// </summary>
        public int? Limit { get; init; }

        /// <summary>
        /// Filter beatmaps by the mods required to play them.
        /// </summary>
        public Mods? Mods { get; init; }
    }
}
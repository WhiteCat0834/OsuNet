using Newtonsoft.Json;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get information about events.
    /// </summary>
    public record EventInfo(
        /// <summary>
        /// Event HTML code.
        /// </summary>
        [JsonProperty("display_html")] string DisplayHtml,

        /// <summary>
        /// Unique beatmap SET ID.
        /// </summary>
        [JsonProperty("beatmap_id")] ulong? BeatmapId,

        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [JsonProperty("beatmapset_id")] ulong? BeatmapSetId,

        /// <summary>
        /// Date and time the event was received.
        /// </summary>
        [JsonProperty("date")] DateTime DateTime,

        /// <summary>
        /// How "epic" this event is (between 1 and 32).
        /// </summary>
        [JsonProperty("epicfactor")] byte EpicFactor
    );
}
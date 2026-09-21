using System.Text.Json.Serialization;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get information about events.
    /// </summary>
    public record EventInfo(
        /// <summary>
        /// Event HTML code.
        /// </summary>
        [property: JsonPropertyName("display_html")] string DisplayHtml,

        /// <summary>
        /// Unique beatmap SET ID.
        /// </summary>
        [property: JsonPropertyName("beatmap_id")] ulong? BeatmapId,

        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [property: JsonPropertyName("beatmapset_id")] ulong? BeatmapSetId,

        /// <summary>
        /// Date and time the event was received.
        /// </summary>
        [property: JsonPropertyName("date")] DateTime DateTime,

        /// <summary>
        /// How "epic" this event is (between 1 and 32).
        /// </summary>
        [property: JsonPropertyName("epicfactor")] byte EpicFactor
    );
}
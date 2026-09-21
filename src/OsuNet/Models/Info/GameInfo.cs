using OsuNet.Enums;
using System.Text.Json.Serialization;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about the game.
    /// </summary>
    public record GameInfo(
        /// <summary>
        /// Unique game ID.
        /// </summary>
        [property: JsonPropertyName("game_id")] ulong GameId,

        /// <summary>
        /// Date and time the game started.
        /// </summary>
        [property: JsonPropertyName("start_time")] DateTime StartTime,

        /// <summary>
        /// Date and time the game ended.
        /// </summary>
        [property: JsonPropertyName("end_time")] DateTime? EndTime,

        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [property: JsonPropertyName("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Couldn't find.
        /// </summary>
        [property: JsonPropertyName("match_type")] string? MatchType,

        /// <summary>
        /// The type of evaluation in this game.
        /// </summary>
        [property: JsonPropertyName("scoring_type")] Scoring ScoringType,

        /// <summary>
        /// Team type.
        /// </summary>
        [property: JsonPropertyName("team_type")] TeamType TeamType,

        /// <summary>
        /// Mods used on this game.
        /// </summary>
        [property: JsonPropertyName("mods")] Mods Mods,

        /// <summary>
        /// Information about the players.
        /// </summary>
        [property: JsonPropertyName("scores")] IReadOnlyList<ScoreInfo> Scores,

        /// <summary>
        /// Game Mode. (Default Osu)
        /// </summary>
        [property: JsonPropertyName("play_mode")] BeatmapMode PlayMode = BeatmapMode.Osu
    );
}
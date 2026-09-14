using Newtonsoft.Json;
using OsuNet.Enums;

namespace OsuNet.Models.Info {
    /// <summary>
    /// Get general information about the game.
    /// </summary>
    public record GameInfo(
        /// <summary>
        /// Unique game ID.
        /// </summary>
        [JsonProperty("game_id")] ulong GameId,

        /// <summary>
        /// Date and time the game started.
        /// </summary>
        [JsonProperty("start_time")] DateTime StartTime,

        /// <summary>
        /// Date and time the game ended.
        /// </summary>
        [JsonProperty("end_time")] DateTime? EndTime,

        /// <summary>
        /// Unique beatmap ID.
        /// </summary>
        [JsonProperty("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Couldn't find.
        /// </summary>
        [JsonProperty("match_type")] string? MatchType,

        /// <summary>
        /// The type of evaluation in this game.
        /// </summary>
        [JsonProperty("scoring_type")] Scoring ScoringType,

        /// <summary>
        /// Team type.
        /// </summary>
        [JsonProperty("team_type")] TeamType TeamType,

        /// <summary>
        /// Mods used on this game.
        /// </summary>
        [JsonProperty("mods")] Mods Mods,

        /// <summary>
        /// Information about the players.
        /// </summary>
        [JsonProperty("scores")] IReadOnlyList<ScoreInfo> Scores,

        /// <summary>
        /// Game Mode. (Default Osu)
        /// </summary>
        [JsonProperty("play_mode")] BeatmapMode PlayMode = BeatmapMode.Osu
    );
}
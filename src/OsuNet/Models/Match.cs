using OsuNet.Models.Info;
using System.Text.Json.Serialization;

namespace OsuNet.Models {
    /// <summary>
    /// Retrieve information about a multiplayer match.
    /// </summary>
    public record Match(
        /// <summary>
        /// Gets basic information about the match.
        /// </summary>
        [property: JsonPropertyName("match")] MatchInfo MatchInfo,

        /// <summary>
        /// Gets basic information about games.
        /// </summary>
        [property: JsonPropertyName("games")] IReadOnlyList<GameInfo> Games
    );
}
using Newtonsoft.Json;
using OsuNet.Models.Info;

namespace OsuNet.Models {
    /// <summary>
    /// Retrieve information about a multiplayer match.
    /// </summary>
    public record Match(
        /// <summary>
        /// Gets basic information about the match.
        /// </summary>
        [JsonProperty("match")] MatchInfo MatchInfo,

        /// <summary>
        /// Gets basic information about games.
        /// </summary>
        [JsonProperty("games")] IReadOnlyList<GameInfo> Games
    );
}
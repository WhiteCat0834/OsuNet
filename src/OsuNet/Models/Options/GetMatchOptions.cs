namespace OsuNet.Models.Options {
    /// <summary>
    /// Represents the options for retrieving multiplayer match data.
    /// </summary>
    public class GetMatchOptions {
        /// <summary>
        /// MatchId is a required option. The unique identifier of the multiplayer match.
        /// </summary>
        public ulong? MatchId { get; set; }
    }
}
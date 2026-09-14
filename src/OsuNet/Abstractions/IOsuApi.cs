namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents the main entry point for interacting with the osu! API.
    /// </summary>
    public interface IOsuApi {
        /// <summary>
        /// Gets the module responsible for retrieving osu! user information and play history.
        /// </summary>
        IUserModule User { get; }

        /// <summary>
        /// Gets the module responsible for retrieving osu! beatmap information.
        /// </summary>
        IBeatmapModule Beatmaps { get; }

        /// <summary>
        /// Gets the module responsible for retrieving osu! beatmap scores and leaderboards.
        /// </summary>
        IScoresModule Scores { get; }

        /// <summary>
        /// Gets the module responsible for retrieving osu! multiplayer match information.
        /// </summary>
        IMultiplayerModule Multiplayer { get; }

        /// <summary>
        /// Gets the module responsible for retrieving osu! replay information.
        /// </summary>
        IReplayModule Replay { get; }
    }
}
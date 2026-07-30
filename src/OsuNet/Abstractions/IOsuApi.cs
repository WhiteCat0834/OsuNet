namespace OsuNet.Abstractions {
    public interface IOsuApi : IApiRequester {
        IUserModule User { get; }
        IBeatmapModule Beatmaps { get; }
        IScoresModule Scores { get; }
        IMultiplayerModule Multiplayer { get; }
        IReplayModule Replay { get; }
    }
}

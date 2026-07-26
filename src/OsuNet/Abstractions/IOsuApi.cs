namespace OsuNet.Abstractions {
    public interface IOsuApi {
        string AccessToken { get; set; }
        Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default);

        IUserModule User { get; }
        IBeatmapModule Beatmaps { get; }
        IScoresModule Scores { get; }
        IMultiplayerModule Multiplayer { get; }
        IReplayModule Replay { get; }
    }
}

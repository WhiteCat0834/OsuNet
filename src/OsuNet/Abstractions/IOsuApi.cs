using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IOsuApi {
        Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default);
        Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default);
        Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default);
        Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default);
        Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default);
        Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default);
        Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default);
    }
}

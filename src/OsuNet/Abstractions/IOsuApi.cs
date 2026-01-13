using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IOsuApi {
        Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options);
        Task<User[]> GetUserAsync(GetUserOptions options);
        Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options);
        Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options);
        Task<Scores[]> GetScoresAsync(GetScoresOptions options);
        Task<Match> GetMatchAsync(GetMatchOptions options);
        Task<Replay> GetReplayAsync(GetReplayOptions options);
    }
}

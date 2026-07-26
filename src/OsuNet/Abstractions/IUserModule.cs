using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IUserModule {
        Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default);
        Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default);
        Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default);
    }
}

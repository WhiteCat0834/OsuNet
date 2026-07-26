using OsuNet.Core;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet {
    public partial class OsuApi {
        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="options">Configuration options for specifying which user(s) to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="User"/> objects matching the specified criteria.</returns>
        public async Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("u", options.User?.ToString()),
                ("m", ((int?)options.Mode)?.ToString()),
                ("type", options.Type),
                ("event_days", options.EventDays)
            );

            return await getAsync<User[]>("get_user", query, cancellationToken);
        }

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's best scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserBest"/> objects representing the user's highest-ranked scores.</returns>
        public async Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );

            return await getAsync<UserBest[]>("get_user_best", query, cancellationToken);
        }

        /// <summary>
        /// Gets the user's ten most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's recent plays.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserRecent"/> objects representing the user's most recent score submissions.</returns>
        public async Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );

            return await getAsync<UserRecent[]>("get_user_recent", query, cancellationToken);
        }
    }
}

using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    /// <summary>
    /// Represents a module that provides functionality for interacting with osu! user profiles and play history.
    /// </summary>
    public class UserModule : IUserModule {
        private readonly IApiRequester requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModule"/> class.
        /// </summary>
        /// <param name="requester">The <see cref="IApiRequester"/> implementation used to handle API requests.</param>
        public UserModule(IApiRequester requester) { 
            this.requester = requester;
        }

        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="options">Configuration options for specifying which user(s) to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Collection of <see cref="User"/> objects matching the specified criteria.</returns>
        public async Task<IReadOnlyList<User>> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("u", options.User?.ToString()),
                ("m", ((int?)options.Mode)?.ToString()),
                ("type", options.Type),
                ("event_days", options.EventDays)
            );

            return await requester.GetAsync<IReadOnlyList<User>>("get_user", query, cancellationToken);
        }

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's best scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Collection of <see cref="UserBest"/> objects representing the user's highest-ranked scores.</returns>
        public async Task<IReadOnlyList<UserBest>> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );

            return await requester.GetAsync<IReadOnlyList<UserBest>>("get_user_best", query, cancellationToken);
        }

        /// <summary>
        /// Gets the user's ten most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's recent plays.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Collection of <see cref="UserRecent"/> objects representing the user's most recent score submissions.</returns>
        public async Task<IReadOnlyList<UserRecent>> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );

            return await requester.GetAsync<IReadOnlyList<UserRecent>>("get_user_recent", query, cancellationToken);
        }
    }
}

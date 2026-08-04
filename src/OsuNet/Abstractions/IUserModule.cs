using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for a module that provides functionality for retrieving osu! user profiles and play history.
    /// </summary>
    public interface IUserModule {
        /// <summary>
        /// Asynchronously retrieves general user information based on the specified criteria.
        /// </summary>
        /// <param name="options">Configuration options for specifying which user(s) to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an array of <see cref="User"/> objects matching the specified criteria.</returns>
        Task<IReadOnlyList<User>> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves the top scores for the specified user.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's best scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an array of <see cref="UserBest"/> objects representing the user's highest-ranked scores.</returns>
        Task<IReadOnlyList<UserBest>> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves the user's most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's recent plays.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an array of <see cref="UserRecent"/> objects representing the user's most recent score submissions.</returns>
        Task<IReadOnlyList<UserRecent>> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default);
    }
}
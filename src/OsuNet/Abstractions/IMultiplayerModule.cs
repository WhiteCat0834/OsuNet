using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for a module that provides functionality for retrieving osu! multiplayer match information.
    /// </summary>
    public interface IMultiplayerModule {
        /// <summary>
        /// Asynchronously retrieves information about a specific multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing a <see cref="Match"/> object with detailed information about the specified multiplayer match.</returns>
        Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default);
    }
}
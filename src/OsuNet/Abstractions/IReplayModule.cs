using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for a module that provides functionality for retrieving osu! replay information.
    /// </summary>
    public interface IReplayModule {
        /// <summary>
        /// Asynchronously retrieves replay data for a specified score.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing a <see cref="Replay"/> object with the requested replay data.</returns>
        Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default);
    }
}
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for a module that provides functionality for retrieving osu! beatmap information.
    /// </summary>
    public interface IBeatmapModule {
        /// <summary>
        /// Asynchronously retrieves general beatmap information based on the specified search criteria.
        /// </summary>
        /// <param name="options">Configuration options for filtering and specifying beatmap search criteria.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an array of <see cref="Beatmap"/> objects matching the specified criteria.</returns>
        Task<IReadOnlyList<Beatmap>> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default);
    }
}
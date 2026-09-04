using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for a module that provides functionality for retrieving osu! beatmap scores and leaderboards.
    /// </summary>
    public interface IScoresModule {
        /// <summary>
        /// Asynchronously retrieves the top scores for a specified beatmap.
        /// </summary>
        /// <param name="options">Configuration options for querying beatmap scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an array of <see cref="Score"/> objects representing the leaderboard entries for the specified beatmap.</returns>
        Task<IReadOnlyList<Score>> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default);
    }
}
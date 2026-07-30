using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    public class ScoresModule : IScoresModule {
        private readonly IApiRequester requester;

        public ScoresModule(IApiRequester requester) {
            this.requester = requester;
        }

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="options">Configuration options for querying beatmap scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Score"/> objects representing the leaderboard entries for the specified beatmap.</returns>
        public async Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("b", options.BeatmapId?.ToString()),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("mods", ((int?)options.Mods)?.ToString()),
                ("type", options.Type),
                ("limit", options.Limit?.ToString())
            );

            return await requester.GetAsync<Score[]>("get_scores", query, cancellationToken);
        }
    }
}

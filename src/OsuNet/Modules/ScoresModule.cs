using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    internal class ScoresModule : IScoresModule {
        private readonly IOsuApi osuApi;

        internal ScoresModule(IOsuApi osuApi) {
            this.osuApi = osuApi;
        }

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="options">Configuration options for querying beatmap scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Score"/> objects representing the leaderboard entries for the specified beatmap.</returns>
        public async Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", osuApi.AccessToken),
                ("b", options.BeatmapId?.ToString()),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("mods", options.Mods?.ToString()),
                ("type", options.Type),
                ("limit", options.Limit?.ToString())
            );

            return await osuApi.GetAsync<Score[]>("get_scores", query, cancellationToken);
        }
    }
}

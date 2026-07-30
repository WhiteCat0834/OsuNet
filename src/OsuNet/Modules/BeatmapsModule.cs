using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    public class BeatmapsModule : IBeatmapModule {
        private readonly IApiRequester requester;

        public BeatmapsModule(IApiRequester requester) {
            this.requester = requester;
        }

        /// <summary>
        /// Retrieve general beatmap information.
        /// </summary>
        /// <param name="options">Configuration options for filtering and specifying beatmap search criteria.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Beatmap"/> objects matching the specified criteria.</returns>
        public async Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("since", options.Since?.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")),
                ("s", options.BeatmapSetId),
                ("b", options.BeatmapId),
                ("u", options.User),
                ("type", options.Type),
                ("m", options.Mode.HasValue ? (int?)options.Mode : null),
                ("a", options.ConvertedBeatmaps == true ? "1" : "0"),
                ("h", options.Hash),
                ("limit", options.Limit),
                ("mods", ((int?)options.Mods)?.ToString())
            );
            return await requester.GetAsync<Beatmap[]>("get_beatmaps", query, cancellationToken);
        }
    }
}

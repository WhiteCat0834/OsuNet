using OsuNet.Core;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet {
    public partial class OsuApi {
        /// <summary>
        /// Retrieve general beatmap information.
        /// </summary>
        /// <param name="options">Configuration options for filtering and specifying beatmap search criteria.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Beatmap"/> objects matching the specified criteria.</returns>
        public async Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("since", options.Since?.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")),
                ("s", options.BeatmapSetId),
                ("b", options.BeatmapId),
                ("u", options.User),
                ("type", options.Type),
                ("m", options.Mode.HasValue ? (int?)options.Mode : null),
                ("a", options.ConvertedBeatmaps == true ? "1" : "0"),
                ("h", options.Hash),
                ("limit", options.Limit),
                ("mods", options.Mods)
            );
            return await getAsync<Beatmap[]>("get_beatmaps", query, cancellationToken);
        }
    }
}

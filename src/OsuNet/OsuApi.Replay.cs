using OsuNet.Core;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet {
    public partial class OsuApi {
        /// <summary>
        /// Get the replay data of a user's score on a beatmap.<br/>
        /// ⚠️ Rate limit: Maximum 10 requests per minute.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Replay"/> object containing the base64-encoded replay data.</returns>
        public async Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("b", options.BeatmapId.ToString()),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("s", options.ScoreId),
                ("type", options.Type),
                ("mods", ((int?)options.Mods)?.ToString())
            );

            return await getAsync<Replay>("get_replay", query, cancellationToken);
        }
    }
}

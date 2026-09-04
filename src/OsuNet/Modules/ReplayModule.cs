using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    /// <summary>
    /// Represents a module for interacting with replay-related endpoints in the osu! API.
    /// </summary>
    public class ReplayModule : IReplayModule {
        private readonly IApiRequester requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplayModule"/> class.
        /// </summary>
        /// <param name="requester">The API requester used to send requests to the osu! API.</param>
        public ReplayModule(IApiRequester requester) {
            this.requester = requester;
        }

        /// <summary>
        /// Get the replay data of a user's score on a beatmap.<br/>
        /// ⚠️ Rate limit: Maximum 10 requests per minute.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Replay"/> object containing the base64-encoded replay data.</returns>
        public async Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("b", options.BeatmapId.ToString()),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("s", options.ScoreId),
                ("type", options.Type),
                ("mods", ((int?)options.Mods)?.ToString())
            );

            return await requester.GetAsync<Replay>("get_replay", query, cancellationToken);
        }
    }
}

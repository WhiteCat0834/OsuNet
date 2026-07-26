using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    internal class MultiplayerModule : IMultiplayerModule {
        private readonly IOsuApi osuApi;

        internal MultiplayerModule(IOsuApi osuApi) {
            this.osuApi = osuApi;
        }

        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Match"/> object containing detailed information about the specified multiplayer match.</returns>
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", osuApi.AccessToken),
                ("mp", options.MatchId.ToString())
            );

            return await osuApi.GetAsync<Match>("get_match", query, cancellationToken);
        }
    }
}

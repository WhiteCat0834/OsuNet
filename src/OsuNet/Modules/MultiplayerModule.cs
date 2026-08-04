using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Utils;

namespace OsuNet.Modules {
    /// <summary>
    /// Represents a module for interacting with multiplayer-related endpoints in the osu! API.
    /// </summary>
    public class MultiplayerModule : IMultiplayerModule {
        private readonly IApiRequester requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplayerModule"/> class.
        /// </summary>
        /// <param name="requester">The <see cref="IApiRequester"/> implementation used to handle API requests.</param>
        public MultiplayerModule(IApiRequester requester) {
            this.requester = requester;
        }

        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Match"/> object containing detailed information about the specified multiplayer match.</returns>
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", requester.AccessToken),
                ("mp", options.MatchId.ToString())
            );

            return await requester.GetAsync<Match>("get_match", query, cancellationToken);
        }
    }
}

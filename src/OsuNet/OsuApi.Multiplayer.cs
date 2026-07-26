using OsuNet.Core;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet {
    public partial class OsuApi {
        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Match"/> object containing detailed information about the specified multiplayer match.</returns>
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) {
            var query = QueryBuilder.Build(
                ("k", accessToken),
                ("mp", options.MatchId.ToString())
            );

            return await getAsync<Match>("get_match", query, cancellationToken);
        }
    }
}

using System.Net;
using Newtonsoft.Json;
using OsuNet.Models;
using OsuNet.Converters;
using OsuNet.Abstractions;
using OsuNet.Models.Options;

namespace OsuNet {
    /// <summary>
    /// The main class of this library.
    /// </summary>
    public class OsuApi : IOsuApi {
        private const string baseUrl = "https://osu.ppy.sh/api/";
        private static readonly JsonSerializerSettings jsonSettings = new() {
            Converters = { new OsuBoolConverter() }
        };

        private readonly string accessToken;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApi"/> class.
        /// </summary>
        /// <param name="accessToken">Your Osu!API token.</param>
        public OsuApi(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken), "Access token cannot be null or empty.");

            this.accessToken = accessToken;
            httpClient = new HttpClient(new HttpClientHandler { 
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
        }

        private T fromJson<T>(Stream stream) {
            using var reader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(reader);
            var serializer = JsonSerializer.Create(jsonSettings);
            return serializer.Deserialize<T>(jsonReader)!;
        }

        private async Task<T> getAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default) {
            var queryString = string.Join("&", query.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var url = $"{baseUrl}{endpoint}?{queryString}";
            using var response = await httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            return fromJson<T>(stream);
        }

        private static IEnumerable<KeyValuePair<string, string>> buildQuery(params (string Key, object? Value)[] parameters) {
            foreach (var p in parameters) {
                if (p.Value != null) {
                    yield return new KeyValuePair<string, string>(p.Key, p.Value.ToString());
                }
            }
        }

        private IEnumerable<KeyValuePair<string, string>> BeatmapQuery(GetBeatmapsOptions options) {
            return buildQuery(
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
        }

        private IEnumerable<KeyValuePair<string, string>> UserQuery(GetUserOptions options) {
            return buildQuery(
                ("k", accessToken),
                ("u", options.User?.ToString()),
                ("m", ((int?)options.Mode)?.ToString()),
                ("type", options.Type),
                ("event_days", options.EventDays)
            );
        }

        private IEnumerable<KeyValuePair<string, string>> UserBestQuery(GetUserBestOptions options) {
            return buildQuery(
                ("k", accessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );
        }

        private IEnumerable<KeyValuePair<string, string>> UserRecentQuery(GetUserRecentOptions options) {
            return buildQuery(
                ("k", accessToken),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("limit", options.Limit?.ToString()),
                ("type", options.Type)
            );
        }

        private IEnumerable<KeyValuePair<string, string>> ScoresQuery(GetScoresOptions options) {
            return buildQuery(
                ("k", accessToken),
                ("b", options.BeatmapId?.ToString()),
                ("u", options.User),
                ("m", ((int?)options.Mode)?.ToString()),
                ("mods", options.Mods?.ToString()),
                ("type", options.Type),
                ("limit", options.Limit?.ToString())
            );
        }

        private IEnumerable<KeyValuePair<string, string>> MultiplayerQuery(GetMatchOptions options) {
            return buildQuery(
                ("k", accessToken),
                ("mp", options.MatchId.ToString())
            );
        }

        private IEnumerable<KeyValuePair<string, string>> ReplayQuery(GetReplayOptions options) {
            return buildQuery(
                 ("k", accessToken),
                 ("b", options.BeatmapId.ToString()),
                 ("u", options.User),
                 ("m", ((int?)options.Mode)?.ToString()),
                 ("s", options.ScoreId),
                 ("type", options.Type),
                 ("mods", ((int?)options.Mods)?.ToString())
            );
        }

        /// <summary>
        /// Retrieve general beatmap information.
        /// </summary>
        /// <param name="options">Configuration options for filtering and specifying beatmap search criteria.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Beatmap"/> objects matching the specified criteria.</returns>
        public async Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Beatmap[]>("get_beatmaps", BeatmapQuery(options), cancellationToken);

        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="options">Configuration options for specifying which user(s) to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="User"/> objects matching the specified criteria.</returns>
        public async Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<User[]>("get_user", UserQuery(options), cancellationToken);

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's best scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserBest"/> objects representing the user's highest-ranked scores.</returns>
        public async Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<UserBest[]>("get_user_best", UserBestQuery(options), cancellationToken);

        /// <summary>
        /// Gets the user's ten most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's recent plays.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserRecent"/> objects representing the user's most recent score submissions.</returns>
        public async Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<UserRecent[]>("get_user_recent", UserRecentQuery(options), cancellationToken);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="options">Configuration options for querying beatmap scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Score"/> objects representing the leaderboard entries for the specified beatmap.</returns>
        public async Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Score[]>("get_scores", ScoresQuery(options), cancellationToken);

        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Match"/> object containing detailed information about the specified multiplayer match.</returns>
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Match>("get_match", MultiplayerQuery(options), cancellationToken);

        /// <summary>
        /// Get the replay data of a user's score on a beatmap.<br/>
        /// ⚠️ Rate limit: Maximum 10 requests per minute.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Replay"/> object containing the base64-encoded replay data.</returns>
        public async Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Replay>("get_replay", ReplayQuery(options), cancellationToken);
    }
}

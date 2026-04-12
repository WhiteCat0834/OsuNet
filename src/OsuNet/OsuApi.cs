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
        /// <param name="httpClient">HttpClient instance.</param>
        public OsuApi(string accessToken, HttpClient httpClient) {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken), "Access token cannot be null or empty.");

            this.accessToken = accessToken;
            this.httpClient = httpClient ?? new HttpClient();
        }

        private async Task<T> getAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default) {
            var queryString = string.Join("&", query.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var url = $"{baseUrl}{endpoint}?{queryString}";
            using var response = await httpClient.GetAsync(url, cancellationToken);
            string content = await response.Content.ReadAsStringAsync(cancellationToken);

            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(content, jsonSettings)!;
        }

        private static IEnumerable<KeyValuePair<string, string>> buildQuery(params (string Key, object? Value)[] parameters) {
            return parameters.Where(p => p.Value != null)
                             .Select(p => new KeyValuePair<string, string>(p.Key, p.Value!.ToString()!));
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
        /// <param name="options"></param>
        /// <returns>Array of beatmap.</returns>
        public async Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Beatmap[]>("get_beatmaps", BeatmapQuery(options), cancellationToken);
        
        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Array of user.</returns>
        public async Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<User[]>("get_user", UserQuery(options), cancellationToken);

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Array of the user's best scores.</returns>
        public async Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<UserBest[]>("get_user_best", UserBestQuery(options), cancellationToken);

        /// <summary>
        /// Gets the user's ten most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Array of the user's recent results.</returns>
        public async Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<UserRecent[]>("get_user_recent", UserRecentQuery(options), cancellationToken);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Array of scores.</returns>
        public async Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Score[]>("get_scores", ScoresQuery(options), cancellationToken);

        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Information about a multiplayer match.</returns>
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Match>("get_match", MultiplayerQuery(options), cancellationToken);

        /// <summary>
        /// Get the replay data of a user's score on a beatmap.<br/>You are only allowed to do 10 requests per minute.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Replay data of a user's score on a beatmap.</returns>
        public async Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default) =>
            await getAsync<Replay>("get_replay", ReplayQuery(options), cancellationToken);
    }
}

using Newtonsoft.Json;
using OsuNet.Abstractions;
using OsuNet.Converters;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;
using System.Net;

namespace OsuNet {
    /// <summary>
    /// The main class of this library.
    /// </summary>
    public partial class OsuApi : IOsuApi {
        public string AccessToken { get; set; }
        private readonly HttpClient httpClient;
        private const string baseUrl = "https://osu.ppy.sh/api/";
        private static readonly JsonSerializerSettings jsonSettings = new() {
            Converters = { new OsuBoolConverter() }
        };

        public IBeatmapModule Beatmaps { get; }
        public IUserModule User { get; }
        public IScoresModule Scores { get; }
        public IMultiplayerModule Multiplayer { get; }
        public IReplayModule Replay { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApi"/> class.
        /// </summary>
        /// <param name="accessToken">Your Osu!API token.</param>
        public OsuApi(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken), "Access token cannot be null or empty.");

            this.AccessToken = accessToken;
            httpClient = new HttpClient(new HttpClientHandler { 
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");

            this.Beatmaps = new BeatmapsModule(this);
            this.User = new UserModule(this);
            this.Scores = new ScoresModule(this);
            this.Multiplayer = new MultiplayerModule(this);
            this.Replay = new ReplayModule(this);
        }

        private T fromJson<T>(Stream stream) {
            using var reader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(reader);
            var serializer = JsonSerializer.Create(jsonSettings);
            return serializer.Deserialize<T>(jsonReader)!;
        }

        public async Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default) {
            var queryString = string.Join("&", query.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var url = $"{baseUrl}{endpoint}?{queryString}";
            using var response = await httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            return fromJson<T>(stream);
        }

        /// <summary>
        /// Retrieve general beatmap information.
        /// </summary>
        /// <param name="options">Configuration options for filtering and specifying beatmap search criteria.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Beatmap"/> objects matching the specified criteria.</returns>
        /// 
        [Obsolete("Use api.Beatmaps.GetBeatmapsAsync")]
        public async Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default) =>
            await Beatmaps.GetBeatmapsAsync(options, cancellationToken);

        /// <summary>
        /// Retrieve general user information.
        /// </summary>
        /// <param name="options">Configuration options for specifying which user(s) to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="User"/> objects matching the specified criteria.</returns>
        /// 
        [Obsolete("Use api.User.GetUserAsync")]
        public async Task<User[]> GetUserAsync(GetUserOptions options, CancellationToken cancellationToken = default) =>
            await User.GetUserAsync(options, cancellationToken);

        /// <summary>
        /// Get the top scores for the specified user.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's best scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserBest"/> objects representing the user's highest-ranked scores.</returns>
        /// 
        [Obsolete("Use api.User.GetUserBestAsync")]
        public async Task<UserBest[]> GetUserBestAsync(GetUserBestOptions options, CancellationToken cancellationToken = default) =>
            await User.GetUserBestAsync(options, cancellationToken);

        /// <summary>
        /// Gets the user's ten most recent plays over the last 24 hours.
        /// </summary>
        /// <param name="options">Configuration options for retrieving user's recent plays.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="UserRecent"/> objects representing the user's most recent score submissions.</returns>
        /// 
        [Obsolete("Use api.User.GetUserRecentAsync")]
        public async Task<UserRecent[]> GetUserRecentAsync(GetUserRecentOptions options, CancellationToken cancellationToken = default) =>
            await User.GetUserRecentAsync(options, cancellationToken);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="options">Configuration options for querying beatmap scores.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>Array of <see cref="Score"/> objects representing the leaderboard entries for the specified beatmap.</returns>
        /// 
        [Obsolete("Use api.Scores.GetScoresAsync")]
        public async Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default) =>
            await Scores.GetScoresAsync(options, cancellationToken);

        /// <summary>
        /// Retrieve information about a multiplayer match.
        /// </summary>
        /// <param name="options">Configuration options for specifying which multiplayer match to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Match"/> object containing detailed information about the specified multiplayer match.</returns>
        /// 
        [Obsolete("Use api.Multiplayer.GetMatchAsync")]
        public async Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default) =>
            await Multiplayer.GetMatchAsync(options, cancellationToken);

        /// <summary>
        /// Get the replay data of a user's score on a beatmap.<br/>
        /// ⚠️ Rate limit: Maximum 10 requests per minute.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns><see cref="Replay"/> object containing the base64-encoded replay data.</returns>
        /// 
        [Obsolete("Use api.Replay.GetReplayAsync")]
        public async Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default) =>
            await Replay.GetReplayAsync(options, cancellationToken);
    }
}

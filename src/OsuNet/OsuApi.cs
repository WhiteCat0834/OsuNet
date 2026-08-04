using Newtonsoft.Json;
using OsuNet.Abstractions;
using OsuNet.Converters;
using OsuNet.Modules;
using System.Net;

namespace OsuNet {
    /// <summary>
    /// The main class of this library.
    /// </summary>
    public partial class OsuApi : IOsuApi {
        /// <summary>
        /// Osu!API token.
        /// </summary>
        public string AccessToken { get; set; }
        private readonly HttpClient httpClient;
        private const string baseUrl = "https://osu.ppy.sh/api/";
        private static readonly JsonSerializerSettings jsonSettings = new() {
            Converters = { new OsuBoolConverter() }
        };

        /// <summary>
        /// Represents a module for interacting with beatmap-related endpoints in the osu! API.
        /// </summary>
        public IBeatmapModule Beatmaps { get; }

        /// <summary>
        /// Represents a module for interacting with user-related endpoints in the osu! API.
        /// </summary>
        public IUserModule User { get; }

        /// <summary>
        /// Represents a module for interacting with score-related endpoints in the osu! API.
        /// </summary>
        public IScoresModule Scores { get; }

        /// <summary>
        /// Represents a module for interacting with multiplayer-related endpoints in the osu! API.
        /// </summary>
        public IMultiplayerModule Multiplayer { get; }

        /// <summary>
        /// Represents a module for interacting with replay-related endpoints in the osu! API.
        /// </summary>
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
    }
}

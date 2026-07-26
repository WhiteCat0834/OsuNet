using System.Net;
using Newtonsoft.Json;
using OsuNet.Converters;
using OsuNet.Abstractions;

namespace OsuNet {
    /// <summary>
    /// The main class of this library.
    /// </summary>
    public partial class OsuApi : IOsuApi {
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
    }
}

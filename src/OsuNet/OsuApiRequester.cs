using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using OsuNet.Abstractions;
using OsuNet.Converters;

namespace OsuNet {
    /// <summary>
    /// Default implementation of the <see cref="IApiRequester"/> interface for making HTTP requests to the osu! API.
    /// Handles authentication, URL construction, automatic GZip/Deflate decompression, and JSON deserialization.
    /// </summary>
    public class OsuApiRequester : IApiRequester {

        /// <summary>
        /// Osu!API token.
        /// </summary>
        public string AccessToken { get; set; }
        private readonly HttpClient httpClient;
        private const string baseUrl = "https://osu.ppy.sh/api/";

        /// <summary>
        /// Shared JSON serialization options configured for the osu! API.
        /// </summary>
        private static readonly JsonSerializerOptions jsonOptions = new() {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = {
                new JsonStringEnumConverter(),
                new OsuBoolConverter(),
                new OsuDateTimeConverter()
            }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApiRequester"/> class with the specified access token.
        /// Automatically configures the underlying <see cref="HttpClient"/> to support GZip and Deflate compression 
        /// for optimized data transfer with the osu! API.
        /// </summary>
        /// <param name="accessToken">The osu! API v1 authentication token.</param>
        /// <param name="handler">Optional custom <see cref="HttpMessageHandler"/>.</param>
        public OsuApiRequester(string accessToken, HttpMessageHandler? handler = null) {
            if (string.IsNullOrWhiteSpace(accessToken)) 
                throw new ArgumentNullException(nameof(accessToken), "Access token cannot be null or empty.");

            this.AccessToken = accessToken;

            var innerHandler = handler ?? new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            this.httpClient = new HttpClient(innerHandler);
            if (handler == null) {
                this.httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            }
        }

        /// <summary>
        /// Asynchronously executes an HTTP GET request to the specified API endpoint with the provided query parameters
        /// and returns the deserialized JSON response. Query parameter values are automatically URL-encoded to ensure
        /// safe transmission over HTTP. The method will throw an exception if the server returns a non-successful status code.
        /// </summary>
        /// <typeparam name="T">The expected type of the deserialized JSON response object.</typeparam>
        /// <param name="endpoint">The relative API endpoint path (e.g., "get_beatmaps", "get_user") to append to the base URL.</param>
        /// <param name="query">
        /// A collection of key-value pairs representing the query string parameters to include in the request.
        /// Both keys and values will be URL-encoded using <see cref="Uri.EscapeDataString"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used to cancel the asynchronous operation, including the HTTP request
        /// and the subsequent JSON deserialization.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing the deserialized response object of type <typeparamref name="T"/>.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the HTTP request completes with a non-successful status code (4xx or 5xx).
        /// Propagated by <see cref="HttpResponseMessage.EnsureSuccessStatusCode"/>.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown when the <paramref name="cancellationToken"/> is signaled before the operation completes.
        /// </exception>
        public async Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default) {
            var queryString = string.Join("&", query.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            var url = $"{baseUrl}{endpoint}?{queryString}";

            using var response = await httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<T>(jsonOptions, cancellationToken);

            return result!;
        }
    }
}
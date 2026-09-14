namespace OsuNet.Abstractions {
    /// <summary>
    /// Represents a contract for an HTTP client capable of executing requests to the osu! API.
    /// </summary>
    public interface IApiRequester {
        /// <summary>
        /// Gets or sets the API access token used for authentication when making requests to the osu! API.
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Asynchronously executes a GET request to the specified osu! API endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the expected response object.</typeparam>
        /// <param name="endpoint">The API endpoint to call (e.g., "get_beatmaps", "get_user").</param>
        /// <param name="query">A collection of key-value pairs representing the query string parameters.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the deserialized response of type <typeparamref name="T"/>.</returns>
        Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default);
    }
}
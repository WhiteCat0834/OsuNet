namespace OsuNet.Abstractions {
    public interface IApiRequester {
        string AccessToken { get; set; }
        Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, string>> query, CancellationToken cancellationToken = default);
    }
}

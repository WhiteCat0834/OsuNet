using Newtonsoft.Json;

namespace OsuNet.Models {
    /// <summary>
    /// Get the replay data of a user's score on a map.<br/>You are only allowed to do 10 requests per minute.
    /// </summary>
    public record Replay(
        /// <summary>
        /// Gets information about the replay (Base64 encoded and LZMA compressed).
        /// </summary>
        [JsonProperty("content")] string Content,

        /// <summary>
        /// Gets encoding information.
        /// </summary>
        [JsonProperty("encoding")] string Encoding
    );
}
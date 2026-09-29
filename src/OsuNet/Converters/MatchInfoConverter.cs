using System.Text.Json;
using System.Text.Json.Serialization;
using OsuNet.Models.Info;

namespace OsuNet.Converters {
    /// <summary>
    /// A custom JSON converter for <see cref="MatchInfo"/> that handles cases where the osu! API
    /// returns a number (0) or null instead of a valid object when a match is not found.
    /// </summary>
    public class MatchInfoConverter : JsonConverter<MatchInfo> {

        /// <summary>
        /// Fallback options used for deserialization to prevent infinite recursion.
        /// </summary>
        private static readonly JsonSerializerOptions _fallbackOptions = new() {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = {
                new OsuDateTimeConverter()
            }
        };

        /// <summary>
        /// Reads a JSON value and converts it to a <see cref="MatchInfo"/> object.
        /// Returns null if the API returns a number or null instead of a valid object.
        /// </summary>
        public override MatchInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            if (reader.TokenType == JsonTokenType.Number || reader.TokenType == JsonTokenType.Null) {
                return null;
            }

            return JsonSerializer.Deserialize<MatchInfo>(ref reader, _fallbackOptions);
        }

        /// <summary>
        /// Writes a <see cref="MatchInfo"/> object to the JSON output.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, MatchInfo value, JsonSerializerOptions options) {
            JsonSerializer.Serialize(writer, value, _fallbackOptions);
        }
    }
}
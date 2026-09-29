using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OsuNet.Converters {
    /// <summary>
    /// A custom JSON converter for DateTime values returned by the osu! API v1,
    /// which uses the "yyyy-MM-dd HH:mm:ss" format instead of standard ISO 8601.
    /// </summary>
    public class OsuDateTimeConverter : JsonConverter<DateTime> {
        private const string OsuDateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Reads a JSON string value and converts it to a UTC DateTime. 
        /// Falls back to standard ISO 8601 parsing if the osu! format fails.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type of the object to convert to.</param>
        /// <param name="options">The calling <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>The parsed DateTime in UTC, or default(DateTime) if the string is empty.</returns>
        /// <exception cref="JsonException">Thrown when the date string cannot be parsed.</exception>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            if (reader.TokenType == JsonTokenType.String) {
                string? dateString = reader.GetString();

                if (string.IsNullOrEmpty(dateString)) {
                    return default;
                }

                if (DateTime.TryParseExact(
                        dateString,
                        OsuDateFormat,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                        out DateTime result)) {
                    return result;
                }

                if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result)) {
                    return result;
                }
            }

            throw new JsonException($"Unable to parse date value: {reader.GetString()}");
        }

        /// <summary>
        /// Writes a DateTime value to the JSON output in the "yyyy-MM-dd HH:mm:ss" format.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The DateTime value to serialize.</param>
        /// <param name="options">The calling <see cref="JsonSerializerOptions"/>.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString(OsuDateFormat, CultureInfo.InvariantCulture));
        }
    }
}
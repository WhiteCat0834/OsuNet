using System.Text.Json;
using System.Text.Json.Serialization;

namespace OsuNet.Converters {
    /// <summary>
    /// A custom JSON converter that handles boolean values by serializing them as "1" (true) or "0" (false) strings,
    /// and deserializing them back to boolean values. This is required because the osu! API represents boolean values
    /// as string "1" and "0" instead of standard JSON true/false literals.
    /// </summary>
    public class OsuBoolConverter : JsonConverter<bool> {
        /// <summary>
        /// Reads a JSON value and converts it to a boolean. Returns true if the value is "1", otherwise false.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type of the object to convert to.</param>
        /// <param name="options">The calling <see cref="JsonSerializerOptions"/>.</param>
        /// <returns>True if the JSON value is the string "1"; otherwise, false.</returns>
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return reader.GetString() == "1";
        }

        /// <summary>
        /// Writes a boolean value to the JSON output as a string "1" for true or "0" for false.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The boolean value to serialize.</param>
        /// <param name="options">The calling <see cref="JsonSerializerOptions"/>.</param>
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) {
            writer.WriteStringValue(value ? "1" : "0");
        }
    }
}
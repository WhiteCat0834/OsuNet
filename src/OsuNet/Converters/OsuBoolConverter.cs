using Newtonsoft.Json;

namespace OsuNet.Converters {
    /// <summary>
    /// A custom JSON converter that handles boolean values by serializing them as "1" (true) or "0" (false) strings,
    /// and deserializing them back to boolean values. This is required because the osu! API represents boolean values
    /// as string "1" and "0" instead of standard JSON true/false literals.
    /// </summary>
    public class OsuBoolConverter : JsonConverter<bool> {
        /// <summary>
        /// Writes a boolean value to the JSON output as a string "1" for true or "0" for false.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The boolean value to serialize.</param>
        /// <param name="serializer">The calling <see cref="JsonSerializer"/>.</param>
        public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer) {
            writer.WriteValue(value ? "1" : "0");
        }

        /// <summary>
        /// Reads a JSON value and converts it to a boolean. Returns true if the value is "1", otherwise false.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">The type of the object to convert to.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="hasExistingValue">Indicates whether the existing value has a valid value.</param>
        /// <param name="serializer">The calling <see cref="JsonSerializer"/>.</param>
        /// <returns>True if the JSON value is the string "1"; otherwise, false.</returns>
        public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer) {
            return reader.Value?.ToString() == "1";
        }
    }
}
using System.Globalization;

namespace OsuNet.Utils {
    /// <summary>
    /// Provides utility methods for constructing URL query strings for API requests.
    /// </summary>
    internal class QueryBuilder {
        /// <summary>
        /// Builds an enumerable collection of key-value pairs suitable for URL query strings.
        /// Automatically filters out parameters where the value is <c>null</c> and converts 
        /// values to strings using <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="parameters">An array of tuples containing the parameter name (Key) and its value (Value).</param>
        /// <returns>
        /// An <see cref="IEnumerable{KeyValuePair}"/> of string key-value pairs, excluding any entries with null values.
        /// </returns>
        public static IEnumerable<KeyValuePair<string, string>> Build(params (string Key, object? Value)[] parameters) {
            foreach (var p in parameters) {
                if (p.Value != null) {
                    var stringValue = Convert.ToString(p.Value, CultureInfo.InvariantCulture);
                    yield return new KeyValuePair<string, string>(p.Key, stringValue);
                }
            }
        }
    }
}
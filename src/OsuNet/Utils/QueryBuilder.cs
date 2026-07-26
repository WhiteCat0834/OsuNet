using System.Globalization;

namespace OsuNet.Utils {
    internal class QueryBuilder {
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

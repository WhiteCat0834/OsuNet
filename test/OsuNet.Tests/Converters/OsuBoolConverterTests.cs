using Newtonsoft.Json;
using OsuNet.Converters;

namespace OsuNet.Tests.Converters {
    public class OsuBoolConverterTests {
        [Theory]
        [InlineData(true, "\"1\"")]
        [InlineData(false, "\"0\"")]
        public void OsuBoolConverter_ShouldSerializeCorrectly(bool value, string expectedJson) {
            // Arrange
            var converter = new OsuBoolConverter();
            var settings = new JsonSerializerSettings {
                Converters = new List<JsonConverter> { converter }
            };

            // Act
            var json = JsonConvert.SerializeObject(value, settings);

            // Assert
            Assert.Equal(expectedJson, json);
        }

        [Theory]
        [InlineData("\"1\"", true)]
        [InlineData("\"0\"", false)]
        [InlineData("\"\"", false)]
        [InlineData("\"2\"", false)]
        [InlineData("\"true\"", false)]
        [InlineData("\"false\"", false)]
        [InlineData("\"null\"", false)]
        [InlineData("null", false)]
        public void OsuBoolConverter_ShouldDeserializeCorrectly(string json, bool expectedValue) {
            // Arrange
            var converter = new OsuBoolConverter();
            var settings = new JsonSerializerSettings {
                Converters = new List<JsonConverter> { converter }
            };

            // Act
            var result = JsonConvert.DeserializeObject<bool>(json, settings);

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
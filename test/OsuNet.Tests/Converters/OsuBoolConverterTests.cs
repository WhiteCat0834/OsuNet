using System.Text.Json;
using OsuNet.Converters;

namespace OsuNet.Tests.Converters {
    public class OsuBoolConverterTests {

        private JsonSerializerOptions GetOptions() {
            return new JsonSerializerOptions {
                Converters = { new OsuBoolConverter() }
            };
        }

        [Theory]
        [InlineData(true, "\"1\"")]
        [InlineData(false, "\"0\"")]
        public void OsuBoolConverter_ShouldSerializeCorrectly(bool value, string expectedJson) {
            // Arrange
            var options = GetOptions();

            // Act
            var json = JsonSerializer.Serialize(value, options);

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
            var options = GetOptions();

            // Act
            var result = JsonSerializer.Deserialize<bool>(json, options);

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
using Newtonsoft.Json;
using OsuNet.Converters;

namespace OsuNet.Tests.Converters {
    public class OsuBoolConverterTests {
        [Fact]
        public void OsuBoolConverter_ShouldSerializeCorrectly() {
            // Arrange
            var converter = new OsuBoolConverter();
            var settings = new JsonSerializerSettings {
                Converters = new List<JsonConverter> { converter }
            };

            // Act
            var trueJson = JsonConvert.SerializeObject(true, settings);
            var falseJson = JsonConvert.SerializeObject(false, settings);

            // Assert
            Assert.Equal("\"1\"", trueJson);
            Assert.Equal("\"0\"", falseJson);
        }

        [Fact]
        public void OsuBoolConverter_ShouldDeserializeCorrectly() {
            // Arrange
            var converter = new OsuBoolConverter();
            var settings = new JsonSerializerSettings {
                Converters = new List<JsonConverter> { converter }
            };

            // Act
            var trueValue = JsonConvert.DeserializeObject<bool>("\"1\"", settings);
            var falseValue = JsonConvert.DeserializeObject<bool>("\"0\"", settings);

            // Assert
            Assert.True(trueValue);
            Assert.False(falseValue);
        }
    }
}
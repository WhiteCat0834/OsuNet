using System.Text.Json;
using OsuNet.Converters;

namespace OsuNet.Tests.Converters {
    public class OsuDateTimeConverterTests {

        private JsonSerializerOptions GetOptions() {
            return new JsonSerializerOptions {
                Converters = { new OsuDateTimeConverter() }
            };
        }

        [Fact]
        public void OsuDateTimeConverter_ShouldSerializeCorrectly() {
            // Arrange
            var options = GetOptions();
            var date = new DateTime(2023, 10, 25, 14, 30, 0, DateTimeKind.Utc);
            var expectedJson = "\"2023-10-25 14:30:00\"";

            // Act
            var json = JsonSerializer.Serialize(date, options);

            // Assert
            Assert.Equal(expectedJson, json);
        }

        [Theory]
        [InlineData("\"2023-10-25 14:30:00\"", 2023, 10, 25, 14, 30, 0)]
        [InlineData("\"2023-10-25T14:30:00Z\"", 2023, 10, 25, 14, 30, 0)]
        public void OsuDateTimeConverter_ShouldDeserializeCorrectly(string json, int year, int month, int day, int hour, int minute, int second) {
            // Arrange
            var options = GetOptions();
            var expectedDate = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);

            // Act
            var result = JsonSerializer.Deserialize<DateTime>(json, options);

            // Assert
            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void OsuDateTimeConverter_ShouldThrowOnInvalidDate() {
            // Arrange
            var options = GetOptions();
            var invalidJson = "\"not-a-valid-date\"";

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateTime>(invalidJson, options));
        }
    }
}
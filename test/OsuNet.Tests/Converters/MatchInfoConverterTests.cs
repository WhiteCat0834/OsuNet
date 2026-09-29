using System.Text.Json;
using OsuNet.Converters;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Converters {
    public class MatchInfoConverterTests {

        private JsonSerializerOptions GetOptions() {
            return new JsonSerializerOptions {
                Converters = {
                    new MatchInfoConverter()
                }
            };
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("-1")]
        public void MatchInfoConverter_ShouldReturnNullWhenApiReturnsNumber(string json) {
            // Arrange
            var options = GetOptions();

            // Act
            var result = JsonSerializer.Deserialize<MatchInfo>(json, options);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void MatchInfoConverter_ShouldReturnNullWhenApiReturnsNull() {
            // Arrange
            var options = GetOptions();
            var json = "null";

            // Act
            var result = JsonSerializer.Deserialize<MatchInfo>(json, options);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void MatchInfoConverter_ShouldDeserializeValidObjectCorrectly() {
            // Arrange
            var options = GetOptions();
            var json = @"{""match_id"": 12345, ""name"": ""Test Lobby"", ""start_time"": ""2023-10-25T14:30:00Z"", ""end_time"": null}";

            // Act
            var result = JsonSerializer.Deserialize<MatchInfo>(json, options);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(12345UL, result.MatchId);
            Assert.Equal("Test Lobby", result.Name);
            Assert.Equal(new DateTime(2023, 10, 25, 14, 30, 0, DateTimeKind.Utc), result.StartTime);
            Assert.Null(result.EndTime);
        }

        [Fact]
        public void MatchInfoConverter_ShouldSerializeValidObjectCorrectly() {
            // Arrange
            var options = GetOptions();
            var matchInfo = new MatchInfo(
                MatchId: 98765UL,
                Name: "Serialized Lobby",
                StartTime: new DateTime(2023, 10, 25, 14, 30, 0, DateTimeKind.Utc),
                EndTime: null
            );

            // Act
            var json = JsonSerializer.Serialize(matchInfo, options);

            // Assert
            Assert.Contains("\"match_id\":98765", json);
            Assert.Contains("\"name\":\"Serialized Lobby\"", json);
            Assert.Contains("\"start_time\":\"2023-10-25 14:30:00\"", json);
            Assert.Contains("\"end_time\":null", json);
        }
    }
}
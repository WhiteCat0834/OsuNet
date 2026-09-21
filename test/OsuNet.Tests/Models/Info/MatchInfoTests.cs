using System.Text.Json;
using OsuNet.Converters;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models.Info {
    public class MatchInfoTests {

        private JsonSerializerOptions GetOptions() {
            return new JsonSerializerOptions {
                Converters = { new MatchInfoConverter() }
            };
        }

        [Fact]
        public void MatchInfo_ShouldBeNullIfApiReturnsZero() {
            // Arrange
            var options = GetOptions();
            var json = "0";

            // Act
            var matchInfo = JsonSerializer.Deserialize<MatchInfo>(json, options);

            // Assert
            Assert.Null(matchInfo);
        }

        [Fact]
        public void MatchInfo_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = GetOptions();
            var matchInfo = new MatchInfo(
                MatchId: 789,
                Name: "Test Match",
                StartTime: new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndTime: new DateTime(2023, 1, 2, 0, 0, 0, DateTimeKind.Utc)
            );

            // Act
            var json = JsonSerializer.Serialize(matchInfo, options);
            var deserializedMatchInfo = JsonSerializer.Deserialize<MatchInfo>(json, options);

            // Assert
            Assert.NotNull(deserializedMatchInfo);
            Assert.Equal(matchInfo.MatchId, deserializedMatchInfo.MatchId);
            Assert.Equal(matchInfo.Name, deserializedMatchInfo.Name);
            Assert.Equal(matchInfo.StartTime, deserializedMatchInfo.StartTime);
            Assert.Equal(matchInfo.EndTime, deserializedMatchInfo.EndTime);
        }
    }
}
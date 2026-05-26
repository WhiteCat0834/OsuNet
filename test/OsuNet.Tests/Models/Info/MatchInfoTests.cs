using Newtonsoft.Json;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models.Info {
    public class MatchInfoTests {
        [Fact]
        public void MatchInfo_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var matchInfo = new MatchInfo {
                MatchId = 789,
                Name = "Test Match",
                StartTime = new DateTime(2023, 1, 1),
                EndTime = new DateTime(2023, 1, 2)
            };

            // Act
            var json = JsonConvert.SerializeObject(matchInfo);
            var deserializedMatchInfo = JsonConvert.DeserializeObject<MatchInfo>(json);

            // Assert
            Assert.NotNull(deserializedMatchInfo);
            Assert.Equal(matchInfo.MatchId, deserializedMatchInfo.MatchId);
            Assert.Equal(matchInfo.Name, deserializedMatchInfo.Name);
            Assert.Equal(matchInfo.StartTime, deserializedMatchInfo.StartTime);
            Assert.Equal(matchInfo.EndTime, deserializedMatchInfo.EndTime);
        }
    }
}
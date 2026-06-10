using Newtonsoft.Json;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models.Info {
    public class MatchInfoTests {
        [Fact]
        public void MatchInfo_ShouldBeNullIfZero() {
            // Arrange & Act
            var matchInfo = (MatchInfo)0;

            // Assert
            Assert.Equal(matchInfo.MatchId, (ulong)0);
            Assert.Null(matchInfo.Name);
            Assert.Equal(matchInfo.StartTime, new DateTime(0001, 01, 01));
            Assert.Null(matchInfo.EndTime);
        }

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
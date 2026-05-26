using Newtonsoft.Json;
using OsuNet.Models;

namespace OsuNet.Tests.Models {
    public class ReplayTests {
        [Fact]
        public void Replay_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var replay = new Replay {
                Content = "ReplayContent",
                Encoding = "Base64"
            };

            // Act
            var json = JsonConvert.SerializeObject(replay);
            var deserializedReplay = JsonConvert.DeserializeObject<Replay>(json);

            // Assert
            Assert.NotNull(deserializedReplay);
            Assert.Equal(replay.Content, deserializedReplay.Content);
            Assert.Equal(replay.Encoding, deserializedReplay.Encoding);
        }
    }
}

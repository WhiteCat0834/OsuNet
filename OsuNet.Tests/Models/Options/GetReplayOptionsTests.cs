using Newtonsoft.Json;
using OsuNet.Models.Options;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Options {
    public class GetReplayOptionsTests {
        [Fact]
        public void GetReplayOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetReplayOptions {
                BeatmapId = 12345,
                User = "TestUser",
                Mode = BeatmapMode.Osu,
                ScoreId = "score123",
                Type = "string",
                Mods = Mods.Hidden
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetReplayOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.BeatmapId, deserializedOptions.BeatmapId);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.ScoreId, deserializedOptions.ScoreId);
            Assert.Equal(options.Type, deserializedOptions.Type);
            Assert.Equal(options.Mods, deserializedOptions.Mods);
        }

        [Fact]
        public void GetReplayOptions_ShouldThrowException_WhenBeatmapIdIsInvalid() {
            // Arrange
            var options = new GetReplayOptions();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => options.BeatmapId = 0);
        }

        [Fact]
        public void GetReplayOptions_ShouldThrowException_WhenUserIsInvalid() {
            // Arrange
            var options = new GetReplayOptions();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => options.User = "");
        }
    }
}
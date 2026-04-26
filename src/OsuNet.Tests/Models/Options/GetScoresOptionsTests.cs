using Newtonsoft.Json;
using OsuNet.Models.Options;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Options {
    public class GetScoresOptionsTests {
        [Fact]
        public void GetScoresOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetScoresOptions {
                BeatmapId = 12345,
                User = "TestUser",
                Mode = BeatmapMode.Osu,
                Mods = Mods.Hidden,
                Type = "string",
                Limit = 50
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetScoresOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.BeatmapId, deserializedOptions.BeatmapId);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.Mods, deserializedOptions.Mods);
            Assert.Equal(options.Type, deserializedOptions.Type);
            Assert.Equal(options.Limit, deserializedOptions.Limit);
        }
    }
}
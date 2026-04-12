using Newtonsoft.Json;
using OsuNet.Models.Options;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Options {
    public class GetBeatmapsOptionsTests {
        [Fact]
        public void GetBeatmapsOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetBeatmapsOptions {
                Since = new DateTime(2023, 1, 1),
                BeatmapSetId = 12345,
                BeatmapId = 67890,
                User = "TestUser",
                Type = "string",
                Mode = BeatmapMode.Osu,
                ConvertedBeatmaps = true,
                Hash = "hash123",
                Limit = 100,
                Mods = Mods.Hidden
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetBeatmapsOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.Since, deserializedOptions.Since);
            Assert.Equal(options.BeatmapSetId, deserializedOptions.BeatmapSetId);
            Assert.Equal(options.BeatmapId, deserializedOptions.BeatmapId);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Type, deserializedOptions.Type);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.ConvertedBeatmaps, deserializedOptions.ConvertedBeatmaps);
            Assert.Equal(options.Hash, deserializedOptions.Hash);
            Assert.Equal(options.Limit, deserializedOptions.Limit);
            Assert.Equal(options.Mods, deserializedOptions.Mods);
        }
    }
}
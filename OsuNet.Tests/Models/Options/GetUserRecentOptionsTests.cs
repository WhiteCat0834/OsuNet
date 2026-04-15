using OsuNet.Models.Options;
using OsuNet.Enums;
using Newtonsoft.Json;

namespace OsuNet.Tests.Models.Options {
    public class GetUserRecentOptionsTests {
        [Fact]
        public void GetUserRecentOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetUserRecentOptions {
                User = "TestUser",
                Mode = BeatmapMode.Osu,
                Limit = 10,
                Type = "string"
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetUserRecentOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.Limit, deserializedOptions.Limit);
            Assert.Equal(options.Type, deserializedOptions.Type);
        }
    }
}
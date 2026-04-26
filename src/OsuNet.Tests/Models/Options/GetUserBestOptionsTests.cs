using Newtonsoft.Json;
using OsuNet.Models.Options;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Options {
    public class GetUserBestOptionsTests {
        [Fact]
        public void GetUserBestOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetUserBestOptions {
                User = "TestUser",
                Mode = BeatmapMode.Osu,
                Limit = 10,
                Type = "string"
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetUserBestOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.Limit, deserializedOptions.Limit);
            Assert.Equal(options.Type, deserializedOptions.Type);
        }
    }
}
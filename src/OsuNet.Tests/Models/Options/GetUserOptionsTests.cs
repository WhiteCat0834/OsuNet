using Newtonsoft.Json;
using OsuNet.Models.Options;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Options {
    public class GetUserOptionsTests {
        [Fact]
        public void GetUserOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetUserOptions {
                User = "TestUser",
                Mode = BeatmapMode.Osu,
                Type = "string",
                EventDays = 7
            };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetUserOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.User, deserializedOptions.User);
            Assert.Equal(options.Mode, deserializedOptions.Mode);
            Assert.Equal(options.Type, deserializedOptions.Type);
            Assert.Equal(options.EventDays, deserializedOptions.EventDays);
        }

        [Fact]
        public void GetUserOptions_ShouldThrowException_WhenUserIsInvalid() {
            // Arrange
            var options = new GetUserOptions();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => options.User = null);
        }
    }
}
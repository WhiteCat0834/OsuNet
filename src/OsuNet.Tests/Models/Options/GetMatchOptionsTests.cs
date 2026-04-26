using Newtonsoft.Json;
using OsuNet.Models.Options;

namespace OsuNet.Tests.Models.Options {
    public class GetMatchOptionsTests {
        [Fact]
        public void GetMatchOptions_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var options = new GetMatchOptions { MatchId = 12345 };

            // Act
            var json = JsonConvert.SerializeObject(options);
            var deserializedOptions = JsonConvert.DeserializeObject<GetMatchOptions>(json);

            // Assert
            Assert.NotNull(deserializedOptions);
            Assert.Equal(options.MatchId, deserializedOptions.MatchId);
        }
    }
}
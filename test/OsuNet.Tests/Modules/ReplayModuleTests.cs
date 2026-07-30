using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;

namespace OsuNet.Tests.Modules {
    public class ReplayModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly ReplayModule _module;

        public ReplayModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new ReplayModule(_mockRequester.Object);
        }

        [Fact]
        public async Task GetReplayAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetReplayOptions {
                BeatmapId = 12345,
                User = "test_user",
                Mode = 0,
                ScoreId = "999999",
                Type = "id",
                Mods = Mods.DoubleTime | Mods.Hidden
            };
            var expectedReplay = new Replay();
            var token = TestContext.Current.CancellationToken;
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Replay>("get_replay", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedReplay);

            // Act
            var result = await _module.GetReplayAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("12345", queryDict["b"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("999999", queryDict["s"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal("72", queryDict["mods"]);
            Assert.Equal(expectedReplay, result);
        }
    }
}
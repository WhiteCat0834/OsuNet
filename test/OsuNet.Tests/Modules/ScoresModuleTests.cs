using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;

namespace OsuNet.Tests.Modules {
    public class ScoresModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly ScoresModule _module;

        public ScoresModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new ScoresModule(_mockRequester.Object);
        }

        [Fact]
        public async Task GetScoresAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetScoresOptions {
                BeatmapId = 12345,
                User = "test_user",
                Mode = BeatmapMode.Osu,
                Mods = Mods.DoubleTime | Mods.HardRock,
                Type = "id",
                Limit = 50
            };
            var expectedScores = new[] { new Score(), new Score() };
            var token = TestContext.Current.CancellationToken;
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Score[]>("get_scores", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedScores);

            // Act
            var result = await _module.GetScoresAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("12345", queryDict["b"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("80", queryDict["mods"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal("50", queryDict["limit"]);
            Assert.Equal(expectedScores, result);
        }

        [Fact]
        public async Task GetScoresAsync_WithMinimalOptions_OmitsNullValues() {
            // Arrange
            var options = new GetScoresOptions { BeatmapId = 12345 };
            var expectedScores = new[] { new Score() };
            var token = TestContext.Current.CancellationToken;
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Score[]>("get_scores", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedScores);

            // Act
            var result = await _module.GetScoresAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Contains("k", queryDict.Keys);
            Assert.Contains("b", queryDict.Keys);
            Assert.Contains("m", queryDict.Keys);
            Assert.Contains("limit", queryDict.Keys);

            Assert.DoesNotContain("u", queryDict.Keys);
            Assert.DoesNotContain("mods", queryDict.Keys);
            Assert.DoesNotContain("type", queryDict.Keys);

            Assert.Equal(expectedScores, result);
        }
    }
}
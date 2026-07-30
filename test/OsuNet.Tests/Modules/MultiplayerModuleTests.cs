using Moq;
using OsuNet.Abstractions;
using OsuNet.Models.Options;
using OsuNet.Modules;

namespace OsuNet.Tests.Modules {
    public class MultiplayerModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly MultiplayerModule _module;

        public MultiplayerModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new MultiplayerModule(_mockRequester.Object);
        }

        [Fact]
        public async Task GetMatchAsync_WithValidOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetMatchOptions { MatchId = 987654 };
            var expectedMatch = new OsuNet.Models.Match();
            var token = TestContext.Current.CancellationToken;
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<OsuNet.Models.Match>("get_match", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedMatch);

            // Act
            var result = await _module.GetMatchAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("987654", queryDict["mp"]);
            Assert.Equal(expectedMatch, result);
        }
    }
}
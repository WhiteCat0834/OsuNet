using Moq;
using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Tests {

    public class OsuApiWithMoqTests {

        [Fact]
        public void Constructor_WithNullRequester_ThrowsArgumentNullException() {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new OsuApi((IApiRequester)null));
            Assert.Equal("requester", ex.ParamName);
        }

        [Fact]
        public void Constructor_WithMockRequester_InitializesAllModules() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.Setup(r => r.AccessToken).Returns("test_token");

            // Act
            var api = new OsuApi(mockRequester.Object);

            // Assert
            Assert.NotNull(api.Beatmaps);
            Assert.NotNull(api.User);
            Assert.NotNull(api.Scores);
            Assert.NotNull(api.Multiplayer);
            Assert.NotNull(api.Replay);
        }

        [Fact]
        public void AccessToken_Getter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.Setup(r => r.AccessToken).Returns("mocked_token");

            // Act
            var api = new OsuApi(mockRequester.Object);
            var result = api.AccessToken;

            // Assert
            Assert.Equal("mocked_token", result);
            mockRequester.VerifyGet(r => r.AccessToken, Times.Once);
        }

        [Fact]
        public void AccessToken_Setter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.SetupProperty(r => r.AccessToken, "initial_token");

            // Act
            var api = new OsuApi(mockRequester.Object);
            api.AccessToken = "new_token";

            // Assert
            Assert.Equal("new_token", api.AccessToken);
            mockRequester.VerifySet(r => r.AccessToken = "new_token", Times.Once);
        }

        [Fact]
        public async Task BeatmapsModule_UsesRequesterForApiCalls() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.Setup(r => r.AccessToken).Returns("test_token");

            // ИСПРАВЛЕНИЕ: используем IReadOnlyList<Beatmap> вместо List<Beatmap>
            mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Beatmap> { new Beatmap { Title = "Test Beatmap" } });

            var api = new OsuApi(mockRequester.Object);

            // Act
            var result = await api.Beatmaps.GetBeatmapsAsync(new GetBeatmapsOptions { BeatmapId = 123 }, TestContext.Current.CancellationToken);

            // Assert
            Assert.Single(result);
            Assert.Equal("Test Beatmap", result[0].Title);

            mockRequester.Verify(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                "get_beatmaps",
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
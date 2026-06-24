using Moq;
using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Tests {
    public class OsuApiTests {
        private readonly Mock<IOsuApi> mockApi;
        
        public OsuApiTests() { 
            mockApi = new Mock<IOsuApi>();
        }

        [Fact]
        public void OsuApi_ShouldThrowException_WhenAccessTokenIsNullOrEmpty() {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OsuApi(null));
            Assert.Throws<ArgumentNullException>(() => new OsuApi(""));
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetBeatmapsAsync() {
            // Arrange
            var options = new GetBeatmapsOptions();

            mockApi.Setup(api => api.GetBeatmapsAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new Beatmap[0]);

            // Act
            var result = await mockApi.Object.GetBeatmapsAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetBeatmapsAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserAsync() {
            // Arrange
            var options = new GetUserOptions();

            mockApi.Setup(api => api.GetUserAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new User[0]);

            // Act
            var result = await mockApi.Object.GetUserAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserBestAsync() {
            // Arrange
            var options = new GetUserBestOptions();

            mockApi.Setup(api => api.GetUserBestAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new UserBest[0]);

            // Act
            var result = await mockApi.Object.GetUserBestAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserBestAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserRecentAsync() {
            // Arrange
            var options = new GetUserRecentOptions();

            mockApi.Setup(api => api.GetUserRecentAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new UserRecent[0]);

            // Act
            var result = await mockApi.Object.GetUserRecentAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserRecentAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetScoresAsync() {
            // Arrange
            var options = new GetScoresOptions();

            mockApi.Setup(api => api.GetScoresAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new Score[0]);

            // Act
            var result = await mockApi.Object.GetScoresAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetScoresAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetMatchAsync() {
            // Arrange
            var options = new GetMatchOptions();

            mockApi.Setup(api => api.GetMatchAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new OsuNet.Models.Match());

            // Act
            var result = await mockApi.Object.GetMatchAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            mockApi.Verify(api => api.GetMatchAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetReplayAsync() {
            // Arrange
            var options = new GetReplayOptions();

            mockApi.Setup(api => api.GetReplayAsync(options, It.IsAny<CancellationToken>())).ReturnsAsync(new Replay());

            // Act
            var result = await mockApi.Object.GetReplayAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            mockApi.Verify(api => api.GetReplayAsync(options, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
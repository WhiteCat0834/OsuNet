using Moq;
using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Tests {
    public class OsuApiTests {
        [Fact]
        public void OsuApi_ShouldThrowException_WhenAccessTokenIsNullOrEmpty() {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OsuApi(null));
            Assert.Throws<ArgumentNullException>(() => new OsuApi(""));
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetBeatmapsAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetBeatmapsOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetBeatmapsAsync(options, cancellationToken))
                   .ReturnsAsync(new Beatmap[0])
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetBeatmapsAsync(options, cancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetBeatmapsAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetUserOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetUserAsync(options, cancellationToken))
                   .ReturnsAsync(new User[0])
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetUserAsync(options, cancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserBestAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetUserBestOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetUserBestAsync(options, cancellationToken))
                   .ReturnsAsync(new UserBest[0])
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetUserBestAsync(options, cancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserBestAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetUserRecentAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetUserRecentOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetUserRecentAsync(options, cancellationToken))
                   .ReturnsAsync(new UserRecent[0])
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetUserRecentAsync(options, cancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetUserRecentAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetScoresAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetScoresOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetScoresAsync(options, cancellationToken))
                   .ReturnsAsync(new Score[0])
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetScoresAsync(options, cancellationToken);

            // Assert
            Assert.Empty(result);
            mockApi.Verify(api => api.GetScoresAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetMatchAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetMatchOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetMatchAsync(options, cancellationToken))
                   .ReturnsAsync(new OsuNet.Models.Match())
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetMatchAsync(options, cancellationToken);

            // Assert
            Assert.NotNull(result);
            mockApi.Verify(api => api.GetMatchAsync(options, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task IOsuApi_ShouldCallGetReplayAsync() {
            // Arrange
            var mockApi = new Mock<IOsuApi>();
            var options = new GetReplayOptions();
            var cancellationToken = CancellationToken.None;

            mockApi.Setup(api => api.GetReplayAsync(options, cancellationToken))
                   .ReturnsAsync(new Replay())
                   .Verifiable();

            // Act
            var result = await mockApi.Object.GetReplayAsync(options, cancellationToken);

            // Assert
            Assert.NotNull(result);
            mockApi.Verify(api => api.GetReplayAsync(options, cancellationToken), Times.Once);
        }
    }
}
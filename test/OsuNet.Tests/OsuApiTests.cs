using Moq;
using OsuNet.Abstractions;

namespace OsuNet.Tests {
    public class OsuApiTests {

        [Fact]
        public void Constructor_WithValidAccessToken_InitializesAllModules() {
            // Arrange
            string validToken = "valid_test_token";

            // Act
            var api = new OsuApi(validToken);

            // Assert
            Assert.NotNull(api.Beatmaps);
            Assert.NotNull(api.User);
            Assert.NotNull(api.Scores);
            Assert.NotNull(api.Multiplayer);
            Assert.NotNull(api.Replay);
        }

        [Fact]
        public void Constructor_WithNullAccessToken_ThrowsArgumentNullException() {
            // Arrange
            string nullAccessToken = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new OsuApi(nullAccessToken));

            Assert.Equal("accessToken", exception.ParamName);
            Assert.Contains("Access token cannot be null or empty", exception.Message);
        }

        [Fact]
        public void Constructor_WithValidAccessToken_SetsAccessTokenPropertyCorrectly() {
            // Arrange
            string validToken = "my_secret_token_123";

            // Act
            var api = new OsuApi(validToken);

            // Assert
            Assert.Equal(validToken, api.AccessToken);
        }

        [Fact]
        public void Constructor_WithCustomRequester_UsesProvidedRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.Setup(r => r.AccessToken).Returns("mocked_token_123");

            // Act
            var api = new OsuApi("ignored_token", requester: mockRequester.Object);

            // Assert
            Assert.Equal("mocked_token_123", api.AccessToken);
            mockRequester.VerifyGet(r => r.AccessToken, Times.Once);
        }

        [Fact]
        public void Constructor_WithNullRequester_CreatesDefaultRequester() {
            // Arrange
            string validToken = "fallback_token";

            // Act
            var api = new OsuApi(validToken, requester: null);

            // Assert
            Assert.NotNull(api.Beatmaps);
            Assert.Equal(validToken, api.AccessToken);
        }

        [Fact]
        public void Constructor_WithCustomModules_UsesProvidedModules() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            var mockBeatmaps = new Mock<IBeatmapModule>();
            var mockUser = new Mock<IUserModule>();

            // Act
            var api = new OsuApi(
                "test_token",
                requester: mockRequester.Object,
                beatmaps: mockBeatmaps.Object,
                user: mockUser.Object);

            // Assert
            Assert.Same(mockBeatmaps.Object, api.Beatmaps);
            Assert.Same(mockUser.Object, api.User);

            Assert.NotNull(api.Scores);
            Assert.NotNull(api.Multiplayer);
            Assert.NotNull(api.Replay);
        }

        [Fact]
        public void AccessToken_Setter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.SetupProperty(r => r.AccessToken, "initial_token");

            var api = new OsuApi("initial_token", requester: mockRequester.Object);
            string newToken = "updated_secret_token_456";

            // Act
            api.AccessToken = newToken;

            // Assert
            Assert.Equal(newToken, api.AccessToken);
            mockRequester.VerifySet(r => r.AccessToken = newToken, Times.Once);
        }
    }
}
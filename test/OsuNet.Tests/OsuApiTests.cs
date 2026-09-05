using Moq;
using OsuNet.Abstractions;

namespace OsuNet.Tests {
    public class OsuApiTests {
        [Fact]
        public void Constructor_WithNullRequester_ThrowsArgumentNullException() {
            // Arrange
            IApiRequester nullRequester = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new OsuApi(nullRequester));

            Assert.Equal("requester", exception.ParamName);
            Assert.Contains("Value cannot be null", exception.Message);
        }

        [Fact]
        public void Constructor_WithValidRequester_InitializesAllModules() {
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
        public void Constructor_WithValidRequester_AccessTokenGetter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.Setup(r => r.AccessToken).Returns("mocked_token_123");

            // Act
            var api = new OsuApi(mockRequester.Object);
            var result = api.AccessToken;

            // Assert
            Assert.Equal("mocked_token_123", result);
            mockRequester.VerifyGet(r => r.AccessToken, Times.Once);
        }

        [Fact]
        public void Constructor_WithNullAccessToken_ThrowsArgumentNullException() {
            // Arrange
            string nullAccessToken = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new OsuApi(nullAccessToken));

            Assert.NotNull(exception.ParamName);
            Assert.Contains("null", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

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
        public void Constructor_WithValidAccessToken_SetsAccessTokenPropertyCorrectly() {
            // Arrange
            string validToken = "my_secret_token_123";

            // Act
            var api = new OsuApi(validToken);

            // Assert
            Assert.Equal(validToken, api.AccessToken);
        }

        [Fact]
        public void AccessToken_Setter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.SetupProperty(r => r.AccessToken, "initial_token");

            var api = new OsuApi(mockRequester.Object);
            string newToken = "updated_secret_token_456";

            api.AccessToken = newToken;

            // Assert
            Assert.Equal(newToken, api.AccessToken);
            mockRequester.VerifySet(r => r.AccessToken = newToken, Times.Once);
        }
    }
}

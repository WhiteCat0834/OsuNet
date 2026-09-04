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
        public void Constructor_WithValidRequester_AccessTokenSetter_DelegatesToRequester() {
            // Arrange
            var mockRequester = new Mock<IApiRequester>();
            mockRequester.SetupProperty(r => r.AccessToken, "initial_token");

            // Act
            var api = new OsuApi(mockRequester.Object);
            api.AccessToken = "new_updated_token";

            // Assert
            Assert.Equal("new_updated_token", api.AccessToken);
            mockRequester.VerifySet(r => r.AccessToken = "new_updated_token", Times.Once);
        }
    }
}

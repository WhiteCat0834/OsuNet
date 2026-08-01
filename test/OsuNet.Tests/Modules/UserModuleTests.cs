using Moq;
using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;

namespace OsuNet.Tests.Modules {
    public class UserModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly UserModule _module;

        public UserModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new UserModule(_mockRequester.Object);
        }

        [Fact]
        public async Task GetUserAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetUserOptions {
                User = "test_user",
                Mode = 0,
                Type = "id",
                EventDays = 7
            };
            var token = TestContext.Current.CancellationToken;
            var expectedUsers = new[] { new User() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<User[]>("get_user", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedUsers);

            // Act
            var result = await _module.GetUserAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal("7", queryDict["event_days"]);
            Assert.Equal(expectedUsers, result);
        }

        [Fact]
        public async Task GetUserBestAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetUserBestOptions {
                User = "test_user",
                Mode = 0,
                Limit = 10,
                Type = "id"
            };
            var token = TestContext.Current.CancellationToken;
            var expectedBests = new[] { new UserBest() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<UserBest[]>("get_user_best", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedBests);

            // Act
            var result = await _module.GetUserBestAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("10", queryDict["limit"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal(expectedBests, result);
        }

        [Fact]
        public async Task GetUserRecentAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetUserRecentOptions {
                User = "test_user",
                Mode = 0,
                Limit = 5,
                Type = "id"
            };
            var token = TestContext.Current.CancellationToken;
            var expectedRecents = new[] { new UserRecent() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<UserRecent[]>("get_user_recent", It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedRecents);

            // Act
            var result = await _module.GetUserRecentAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("5", queryDict["limit"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal(expectedRecents, result);
        }
    }
}
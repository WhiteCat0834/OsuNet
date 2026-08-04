using System.Collections.Generic;
using System.Linq;
using Moq;
using OsuNet.Abstractions;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;
using Xunit;

namespace OsuNet.Tests.Modules {
    public class UserModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly UserModule _module;

        public UserModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new UserModule(_mockRequester.Object);
        }

        private static void AssertQuery(IEnumerable<KeyValuePair<string, string>> query, string key, string expectedValue) {
            var pair = query.FirstOrDefault(q => q.Key == key);
            Assert.True(pair.Key != null, $"Query does not contain expected key '{key}'");
            Assert.Equal(expectedValue, pair.Value);
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
                .Setup(r => r.GetAsync<IReadOnlyList<User>>( // <--- ИСПРАВЛЕНО
                    "get_user",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedUsers);

            // Act
            var result = await _module.GetUserAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);

            AssertQuery(capturedQuery, "k", "test_access_token");
            AssertQuery(capturedQuery, "u", "test_user");
            AssertQuery(capturedQuery, "m", "0");
            AssertQuery(capturedQuery, "type", "id");
            AssertQuery(capturedQuery, "event_days", "7");

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
                .Setup(r => r.GetAsync<IReadOnlyList<UserBest>>(
                    "get_user_best",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedBests);

            // Act
            var result = await _module.GetUserBestAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);

            AssertQuery(capturedQuery, "k", "test_access_token");
            AssertQuery(capturedQuery, "u", "test_user");
            AssertQuery(capturedQuery, "m", "0");
            AssertQuery(capturedQuery, "limit", "10");
            AssertQuery(capturedQuery, "type", "id");

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
                .Setup(r => r.GetAsync<IReadOnlyList<UserRecent>>(
                    "get_user_recent",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => capturedQuery = query)
                .ReturnsAsync(expectedRecents);

            // Act
            var result = await _module.GetUserRecentAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);

            AssertQuery(capturedQuery, "k", "test_access_token");
            AssertQuery(capturedQuery, "u", "test_user");
            AssertQuery(capturedQuery, "m", "0");
            AssertQuery(capturedQuery, "limit", "5");
            AssertQuery(capturedQuery, "type", "id");

            Assert.Equal(expectedRecents, result);
        }
    }
}
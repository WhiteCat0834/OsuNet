using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Info;
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
            var expectedUsers = new[] { CreateTestUser() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<User>>(
                    "get_user",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => capturedQuery = query)
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
            var expectedBests = new[] { CreateTestUserBest() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<UserBest>>(
                    "get_user_best",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => capturedQuery = query)
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
            var expectedRecents = new[] { CreateTestUserRecent() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<UserRecent>>(
                    "get_user_recent",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => capturedQuery = query)
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

        private static User CreateTestUser() => new User(
            UserId: 123456,
            Username: "test_user",
            JoinDate: DateTime.UtcNow,
            Count300: 1000,
            Count100: 500,
            Count50: 100,
            PlayCount: 2000,
            RankedScore: 5000000,
            TotalScore: 10000000,
            PPRank: 100,
            Level: 100.5f,
            PPRaw: 5000.5f,
            Accuracy: 95.5f,
            CountRankSS: 10,
            CountRankSSH: 5,
            CountRankS: 50,
            CountRankSH: 20,
            CountRankA: 100,
            Country: "US",
            TotalSecondsPlayed: 500000,
            PPCountryRank: 10,
            Events: Array.Empty<EventInfo>()
        );

        private static UserBest CreateTestUserBest() => new UserBest(
            BeatmapId: 12345,
            ScoreId: 98765,
            TotalScore: 1000000,
            MaxCombo: 500,
            Count50: 10,
            Count100: 50,
            Count300: 1000,
            CountMiss: 2,
            CountKatu: 20,
            CountGeki: 100,
            IsPerfect: false,
            EnabledMods: Mods.None,
            UserId: 123456,
            DateTime: DateTime.UtcNow,
            Rank: "S",
            PP: 150.5f,
            ReplayAvailable: true
        );

        private static UserRecent CreateTestUserRecent() => new UserRecent(
            BeatmapId: 12345,
            ScoreId: 98765,
            TotalScore: 1000000,
            MaxCombo: 500,
            Count50: 10,
            Count100: 50,
            Count300: 1000,
            CountMiss: 2,
            CountKatu: 20,
            CountGeki: 100,
            IsPerfect: false,
            EnabledMods: Mods.None,
            UserId: 123456,
            DateTime: DateTime.UtcNow,
            Rank: "A"
        );
    }
}
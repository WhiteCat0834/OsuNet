using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models.Info;
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

            var expectedMatch = CreateTestMatch();
            var token = TestContext.Current.CancellationToken;
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<OsuNet.Models.Match>(
                    "get_match",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => capturedQuery = query)
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

        private static OsuNet.Models.Match CreateTestMatch() => new OsuNet.Models.Match(
            MatchInfo: CreateTestMatchInfo(),
            Games: [CreateTestGameInfo()]
        );

        private static MatchInfo CreateTestMatchInfo() => new MatchInfo(
            MatchId: 987654,
            Name: "Test Multiplayer Lobby",
            StartTime: DateTime.UtcNow,
            EndTime: null
        );

        private static GameInfo CreateTestGameInfo() => new GameInfo(
            GameId: 111111,
            StartTime: DateTime.UtcNow,
            EndTime: DateTime.UtcNow.AddMinutes(5),
            BeatmapId: 12345,
            MatchType: "standard",
            ScoringType: Scoring.Score,
            TeamType: TeamType.HeadToHead,
            Mods: Mods.None,
            Scores: new[] { CreateTestScoreInfo() },
            PlayMode: BeatmapMode.Osu
        );

        private static ScoreInfo CreateTestScoreInfo() => new ScoreInfo(
            Slot: 0,
            Team: Team.Unsupported,
            UserId: 123456,
            TotalScore: 500000,
            MaxCombo: 200,
            Rank: "A",
            Count50: 10,
            Count100: 50,
            Count300: 300,
            CountMiss: 2,
            CountGeki: 20,
            CountKatu: 10,
            IsPerfect: false,
            Pass: true,
            EnabledMods: null
        );
    }
}
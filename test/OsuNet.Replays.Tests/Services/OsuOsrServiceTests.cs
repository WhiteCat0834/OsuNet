using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Replays.Services;

namespace OsuNet.Replays.Tests.Services {
    public class OsuOsrServiceTests {
        private readonly Mock<IOsuApi> mockApi;
        private readonly OsuOsrService service;

        public OsuOsrServiceTests() {
            mockApi = new Mock<IOsuApi>();
            service = new OsuOsrService(mockApi.Object);
        }

        [Fact]
        public async Task GetOsrByteAsync_ShouldReturnByteArray_WhenApiReturnsValidData() {
            // Arrange
            var options = new GetReplayOptions { BeatmapId = 123, User = "TestUser" };
            var replay = new Replay {
                Content = Convert.ToBase64String(new byte[] { 1, 2, 3 })
            };
            var scores = new[] {
                new Score {
                    ScoreId = 1,
                    Username = "TestUser",
                    MaxCombo = 100,
                    TotalScore = 1000,
                    Rank = "S",
                    Count300 = 1,
                    Count100 = 1,
                    Count50 = 1,
                    CountMiss = 1,
                    CountGeki = 1,
                    CountKatu = 1,
                    DateTime = DateTime.Now,
                    EnabledMods = Mods.None,
                    IsPerfect = true,
                    ReplayAvailable = true,
                    PP = 1,
                    UserId = 1
                }
            };
            var beatmaps = new[] {
                new Beatmap {
                    BeatmapId = 123,
                    FileMD5 = "hash",
                    Mode = BeatmapMode.Osu
                }
            };

            mockApi.Setup(api => api.GetReplayAsync(It.IsAny<GetReplayOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(replay);
            mockApi.Setup(api => api.GetScoresAsync(It.IsAny<GetScoresOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(scores);
            mockApi.Setup(api => api.GetBeatmapsAsync(It.IsAny<GetBeatmapsOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(beatmaps);

            // Act
            var result = await service.GetOsrByteAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }
    }
}

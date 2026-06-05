using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Replays.Extensions;
using OsuNet.Replays.Services;

namespace OsuNet.Replays.Tests.Extensions {
    public class OsuApiExtensionsTests {
        private readonly Mock<IOsuApi> mockApi;

        public OsuApiExtensionsTests() {
            mockApi = new Mock<IOsuApi>();
        }

        [Fact]
        public void CreateOsuOsrService_ShouldReturnService() {
            // Act
            var service = mockApi.Object.CreateOsuOsrService();

            // Assert
            Assert.NotNull(service);
            Assert.IsType<OsuOsrService>(service);
        }

        [Fact]
        public async Task GetOsrByteAsync_ShouldCallApiMethodsAndReturnByteArray() {
            // Arrange
            var options = new GetReplayOptions { BeatmapId = 123, User = "TestUser" };
            var ct = CancellationToken.None;
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
            var result = await mockApi.Object.GetOsrByteAsync(options, ct);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }
    }
}

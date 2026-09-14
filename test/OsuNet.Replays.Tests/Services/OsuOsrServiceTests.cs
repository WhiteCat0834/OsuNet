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

            var replay = new Replay(
                Content: Convert.ToBase64String(new byte[] { 1, 2, 3 }),
                Encoding: "LZMA"
            );

            var scores = new[] {
                new Score(
                    ScoreId: 1,
                    TotalScore: 1000,
                    Username: "TestUser",
                    Count300: 1,
                    Count100: 1,
                    Count50: 1,
                    CountMiss: 1,
                    MaxCombo: 100,
                    CountKatu: 1,
                    CountGeki: 1,
                    IsPerfect: true,
                    EnabledMods: Mods.None,
                    UserId: 1,
                    DateTime: DateTime.Now,
                    Rank: "S",
                    PP: 1f,
                    ReplayAvailable: true
                )
            };

            var beatmaps = new[] { CreateTestBeatmap(beatmapId: 123, fileMD5: "hash", mode: BeatmapMode.Osu) };

            mockApi.Setup(api => api.Replay.GetReplayAsync(It.IsAny<GetReplayOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(replay);
            mockApi.Setup(api => api.Scores.GetScoresAsync(It.IsAny<GetScoresOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(scores);
            mockApi.Setup(api => api.Beatmaps.GetBeatmapsAsync(It.IsAny<GetBeatmapsOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(beatmaps);

            // Act
            var result = await service.GetOsrByteAsync(options, TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        private static Beatmap CreateTestBeatmap(ulong beatmapId = 0, string fileMD5 = "", BeatmapMode mode = BeatmapMode.Osu) => new Beatmap(
            BeatmapSetId: 1,
            BeatmapId: beatmapId,
            Approved: default,
            TotalLength: 0,
            HitLength: 0,
            Version: "Normal",
            FileMD5: fileMD5,
            DiffSize: 0f,
            DiffOverall: 0f,
            DiffApproach: 0f,
            DiffDrain: 0f,
            Mode: mode,
            CountNormal: 0,
            CountSlider: 0,
            CountSpinner: 0,
            SubmitDate: null,
            ApprovedDate: null,
            LastUpdate: null,
            Artist: "",
            ArtistUnicode: "",
            Title: "",
            TitleUnicode: "",
            Creator: "",
            CreatorId: 0,
            BPM: 0f,
            Source: "",
            Tags: "",
            GenreId: Genre.Rock,
            LanguageId: Language.French,
            FavouriteCount: 0,
            Rating: 0f,
            Storyboard: false,
            Video: false,
            DownloadUnavailable: false,
            AudioUnavailable: false,
            PlayCount: 0,
            PassCount: 0,
            Packs: "",
            MaxCombo: null,
            DiffAim: null,
            DiffSpeed: null,
            DifficultyRating: 0f
        );
    }
}
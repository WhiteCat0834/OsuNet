using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Moq;
using OsuNet.Abstractions;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Options;
using OsuNet.Modules;

namespace OsuNet.Tests.Modules {
    public class BeatmapsModuleTests {
        private readonly Mock<IApiRequester> _mockRequester;
        private readonly BeatmapsModule _module;

        public BeatmapsModuleTests() {
            _mockRequester = new Mock<IApiRequester>();
            _mockRequester.Setup(r => r.AccessToken).Returns("test_access_token");
            _module = new BeatmapsModule(_mockRequester.Object);
        }

        [Fact]
        public async Task GetBeatmapsAsync_WithAllOptions_CallsRequesterWithCorrectQuery() {
            // Arrange
            var options = new GetBeatmapsOptions {
                Since = new DateTime(2023, 10, 25, 12, 30, 0, DateTimeKind.Utc),
                BeatmapSetId = 12345,
                BeatmapId = 67890,
                User = "test_user",
                Type = "id",
                Mode = BeatmapMode.Osu,
                ConvertedBeatmaps = true,
                Hash = "abcdef123456",
                Limit = 10,
                Mods = Mods.HardRock
            };
            var token = TestContext.Current.CancellationToken;

            var expectedBeatmaps = new[] { CreateTestBeatmap(), CreateTestBeatmap() };

            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => {
                    capturedQuery = query;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);

            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("2023-10-25 12:30:00", queryDict["since"]);
            Assert.Equal("12345", queryDict["s"]);
            Assert.Equal("67890", queryDict["b"]);
            Assert.Equal("test_user", queryDict["u"]);
            Assert.Equal("id", queryDict["type"]);
            Assert.Equal("0", queryDict["m"]);
            Assert.Equal("1", queryDict["a"]);
            Assert.Equal("abcdef123456", queryDict["h"]);
            Assert.Equal("10", queryDict["limit"]);
            Assert.Equal("16", queryDict["mods"]);

            Assert.Equal(expectedBeatmaps, result);
        }

        [Fact]
        public async Task GetBeatmapsAsync_WithMinimalOptions_OmitsNullValues() {
            // Arrange
            var options = new GetBeatmapsOptions {
                BeatmapId = 67890
            };
            var token = TestContext.Current.CancellationToken;

            var expectedBeatmaps = new[] { CreateTestBeatmap() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => {
                    capturedQuery = query;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Contains("k", queryDict.Keys);
            Assert.Contains("b", queryDict.Keys);
            Assert.Contains("a", queryDict.Keys);

            Assert.DoesNotContain("since", queryDict.Keys);
            Assert.DoesNotContain("s", queryDict.Keys);
            Assert.DoesNotContain("u", queryDict.Keys);
            Assert.DoesNotContain("type", queryDict.Keys);
            Assert.DoesNotContain("m", queryDict.Keys);
            Assert.DoesNotContain("h", queryDict.Keys);
            Assert.DoesNotContain("limit", queryDict.Keys);
            Assert.DoesNotContain("mods", queryDict.Keys);

            Assert.Equal("test_access_token", queryDict["k"]);
            Assert.Equal("67890", queryDict["b"]);
            Assert.Equal("0", queryDict["a"]);

            Assert.Equal(expectedBeatmaps, result);
        }

        [Fact]
        public async Task GetBeatmapsAsync_ConvertedBeatmapsFalse_SetsAto0() {
            // Arrange
            var options = new GetBeatmapsOptions {
                BeatmapId = 67890,
                ConvertedBeatmaps = false
            };
            var token = TestContext.Current.CancellationToken;

            var expectedBeatmaps = new[] { CreateTestBeatmap() };
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => {
                    capturedQuery = query;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            Assert.Equal("0", queryDict["a"]);
            Assert.Equal(expectedBeatmaps, result);
        }

        [Fact]
        public async Task GetBeatmapsAsync_PassesCancellationToken() {
            // Arrange
            var options = new GetBeatmapsOptions { BeatmapId = 67890 };
            var token = TestContext.Current.CancellationToken;

            var expectedBeatmaps = new[] { CreateTestBeatmap() };
            CancellationToken capturedToken = default;

            _mockRequester
                .Setup(r => r.GetAsync<IReadOnlyList<Beatmap>>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, ct) => {
                    capturedToken = ct;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.Equal(token, capturedToken);
            Assert.Equal(expectedBeatmaps, result);
        }

        private static Beatmap CreateTestBeatmap() => new Beatmap(
            BeatmapSetId: 12345,
            BeatmapId: 67890,
            Approved: ApproveStatus.Ranked,
            TotalLength: 120,
            HitLength: 110,
            Version: "Normal",
            FileMD5: "abcdef123456",
            DiffSize: 4.0f,
            DiffOverall: 7.0f,
            DiffApproach: 8.5f,
            DiffDrain: 6.0f,
            Mode: BeatmapMode.Osu,
            CountNormal: 200,
            CountSlider: 50,
            CountSpinner: 2,
            SubmitDate: DateTime.UtcNow,
            ApprovedDate: DateTime.UtcNow,
            LastUpdate: DateTime.UtcNow,
            Artist: "Test Artist",
            ArtistUnicode: "Test Artist Unicode",
            Title: "Test Title",
            TitleUnicode: "Test Title Unicode",
            Creator: "Test Creator",
            CreatorId: 123456,
            BPM: 180.0f,
            Source: "Test Source",
            Tags: "test tags",
            GenreId: Genre.Pop,
            LanguageId: Language.Japanese,
            FavouriteCount: 100,
            Rating: 9.5f,
            Storyboard: true,
            Video: false,
            DownloadUnavailable: false,
            AudioUnavailable: false,
            PlayCount: 5000,
            PassCount: 1000,
            Packs: "S1,S2",
            MaxCombo: 300,
            DiffAim: 2.5f,
            DiffSpeed: 2.5f,
            DifficultyRating: 5.0f
        );
    }
}
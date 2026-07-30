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

            var expectedBeatmaps = new[] { new Beatmap(), new Beatmap() };

            // Переменная для захвата переданного query
            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Beatmap[]>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => {
                    capturedQuery = query;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);

            // Преобразуем в словарь для удобной проверки
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

            var expectedBeatmaps = new[] { new Beatmap() };

            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Beatmap[]>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => {
                    capturedQuery = query;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.NotNull(capturedQuery);
            var queryDict = capturedQuery.ToDictionary(x => x.Key, x => x.Value);

            // Проверяем наличие только ожидаемых ключей
            Assert.Contains("k", queryDict.Keys);
            Assert.Contains("b", queryDict.Keys);
            Assert.Contains("a", queryDict.Keys);

            // Проверяем, что null-параметры отсутствуют
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
            Assert.Equal("0", queryDict["a"]); // null == true -> false -> "0"

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

            var expectedBeatmaps = new[] { new Beatmap() };

            IEnumerable<KeyValuePair<string, string>> capturedQuery = null;

            _mockRequester
                .Setup(r => r.GetAsync<Beatmap[]>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, token) => {
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

            var expectedBeatmaps = new[] { new Beatmap() };

            CancellationToken capturedToken = default;

            _mockRequester
                .Setup(r => r.GetAsync<Beatmap[]>(
                    "get_beatmaps",
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, IEnumerable<KeyValuePair<string, string>>, CancellationToken>((endpoint, query, tok) => {
                    capturedToken = tok;
                })
                .ReturnsAsync(expectedBeatmaps);

            // Act
            var result = await _module.GetBeatmapsAsync(options, token);

            // Assert
            Assert.Equal(token, capturedToken);
            Assert.Equal(expectedBeatmaps, result);
        }
    }
}
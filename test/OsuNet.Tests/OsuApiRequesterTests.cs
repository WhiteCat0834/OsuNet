using System.Net;
using System.Text;
using Moq;
using Moq.Protected;
using OsuNet.Models;

namespace OsuNet.Tests {

    public class OsuApiRequesterTests {

        [Fact]
        public async Task GetAsync_FullCoverage_UsesJsonSettingsAndFromJson() {
            // Arrange
            var mockJsonResponse = "[{\"beatmap_id\":123,\"title\":\"Freedom Dive\"}]";

            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(mockJsonResponse, Encoding.UTF8, "application/json")
                });

            var requester = new OsuApiRequester("test_token_for_coverage", mockHandler.Object);

            var query = new List<KeyValuePair<string, string>> {
                new("beatmap_id", "123")
            };

            // Act
            var result = await requester.GetAsync<List<Beatmap>>("get_beatmaps", query, TestContext.Current.CancellationToken);

            // Assert
            Assert.Single(result);
            Assert.Equal("Freedom Dive", result[0].Title);
            Assert.Equal(123UL, result[0].BeatmapId);

            mockHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.ToString().Contains("get_beatmaps?beatmap_id=123")),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetAsync_HandlesHttpError_CoversEnsureSuccessStatusCode() {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.NotFound
                });

            var requester = new OsuApiRequester("test_token", mockHandler.Object);
            var query = new List<KeyValuePair<string, string>>();

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
                requester.GetAsync<string>("get_user", query, TestContext.Current.CancellationToken));

            mockHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetAsync_EncodesQueryParametersCorrectly() {
            HttpRequestMessage? capturedRequest = null;

            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) => capturedRequest = req)
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("\"test_response\"", Encoding.UTF8, "application/json")
                });

            var requester = new OsuApiRequester("test_token", mockHandler.Object);

            var query = new List<KeyValuePair<string, string>> {
                new("search", "hello world & test")
            };

            // Act
            await requester.GetAsync<string>("test_endpoint", query, TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(capturedRequest);
            Assert.Contains("search=hello%20world%20%26%20test", capturedRequest.RequestUri.Query);
            Assert.StartsWith("https://osu.ppy.sh/api/test_endpoint?", capturedRequest.RequestUri.AbsoluteUri);
        }
    }
}
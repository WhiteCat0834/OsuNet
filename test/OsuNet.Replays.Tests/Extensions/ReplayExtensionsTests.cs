using OsuNet.Models;
using OsuNet.Replays.Extensions;
using SevenZip;

namespace OsuNet.Replays.Tests.Extensions {
    public class ReplayExtensionsTests {
        [Fact]
        public async Task DecodeAsync_EmptyContent_ShouldReturnEmptyReplayData() {
            // Arrange
            var replay = new Replay { Content = "" };

            // Act
            var result = await replay.DecodeAsync(TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.ReplayFrames);
            Assert.Equal(0, result.Seed);
        }

        [Fact]
        public async Task DecodeAsync_ValidContent_ShouldParseFramesAndAccumulateTime() {
            // Arrange
            var input = "0|100.5|200.5|1,10|150.0|250.0|2";
            var replay = new Replay { Content = LzmaTestHelper.CompressToBase64(input) };

            // Act
            var result = await replay.DecodeAsync(TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.ReplayFrames.Count);

            var frame1 = result.ReplayFrames[0];
            Assert.Equal(0, frame1.TimeDiff);
            Assert.Equal(0, frame1.Time);
            Assert.Equal(100.5f, frame1.X);
            Assert.Equal(200.5f, frame1.Y);
            Assert.Equal(1, frame1.RawKeys);

            var frame2 = result.ReplayFrames[1];
            Assert.Equal(10, frame2.TimeDiff);
            Assert.Equal(10, frame2.Time);
            Assert.Equal(150.0f, frame2.X);
            Assert.Equal(250.0f, frame2.Y);
            Assert.Equal(2, frame2.RawKeys);
        }

        [Fact]
        public async Task DecodeAsync_ContentWithSeedMarker_ShouldParseSeed() {
            // Arrange
            var input = "-12345|0|0|12345";
            var replay = new Replay { Content = LzmaTestHelper.CompressToBase64(input) };

            // Act
            var result = await replay.DecodeAsync(TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(12345, result.Seed);
            Assert.Empty(result.ReplayFrames);
        }

        [Fact]
        public async Task DecodeAsync_ContentWithInvalidFrame_ShouldSkipInvalidFrame() {
            // Arrange
            var input = "0|100.5|200.5|1,invalid_frame,0|150.0|250.0|2";
            var replay = new Replay { Content = LzmaTestHelper.CompressToBase64(input) };

            // Act
            var result = await replay.DecodeAsync(TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.ReplayFrames.Count);
        }

        [Fact]
        public async Task DecodeAsync_ContentWithEmptySegments_ShouldSkipEmpty() {
            // Arrange
            var input = ",0|100.5|200.5|1,";
            var replay = new Replay { Content = LzmaTestHelper.CompressToBase64(input) };

            // Act
            var result = await replay.DecodeAsync(TestContext.Current.CancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.ReplayFrames);
        }
    }
}

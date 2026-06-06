using OsuNet.Replays.Enums;
using OsuNet.Replays.Models;

namespace OsuNet.Replays.Tests.Models {
    public class ReplayFrameTests {

        [Fact]
        public void OsuKeys_ShouldCastRawKeysCorrectly() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = 5 };

            // Act & Assert
            Assert.Equal((OsuKeys)5, frame.OsuKeys);
        }

        [Fact]
        public void TaikoKeys_ShouldCastRawKeysCorrectly() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = 3 };

            // Act & Assert
            Assert.Equal((TaikoKeys)3, frame.TaikoKeys);
        }

        [Fact]
        public void ManiaKeys_ShouldCastRawKeysCorrectly() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = 15 };

            // Act & Assert
            Assert.Equal((ManiaKeys)15, frame.ManiaKeys);
        }

        [Fact]
        public void CatchKeys_ShouldCastRawKeysCorrectly() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = 1 };

            // Act & Assert
            Assert.Equal((CatchKeys)1, frame.CatchKeys);
        }

        [Fact]
        public void AllKeysProperties_ShouldReflectRawKeysChanges() {
            // Arrange
            var frame = new ReplayFrame();

            // Act
            frame.RawKeys = 7;

            // Assert
            Assert.Equal((OsuKeys)7, frame.OsuKeys);
            Assert.Equal((TaikoKeys)7, frame.TaikoKeys);
            Assert.Equal((ManiaKeys)7, frame.ManiaKeys);
            Assert.Equal((CatchKeys)7, frame.CatchKeys);
        }

        [Fact]
        public void KeysProperties_ShouldHandleZero() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = 0 };

            // Act & Assert
            Assert.Equal((OsuKeys)0, frame.OsuKeys);
            Assert.Equal((TaikoKeys)0, frame.TaikoKeys);
            Assert.Equal((ManiaKeys)0, frame.ManiaKeys);
            Assert.Equal((CatchKeys)0, frame.CatchKeys);
        }

        [Fact]
        public void KeysProperties_ShouldHandleNegativeValues() {
            // Arrange
            var frame = new ReplayFrame { RawKeys = -1 };

            // Act & Assert
            Assert.Equal((OsuKeys)(-1), frame.OsuKeys);
            Assert.Equal((TaikoKeys)(-1), frame.TaikoKeys);
            Assert.Equal((ManiaKeys)(-1), frame.ManiaKeys);
            Assert.Equal((CatchKeys)(-1), frame.CatchKeys);
        }
    }
}
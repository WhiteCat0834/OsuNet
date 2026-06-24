using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Tests.Enums {
    public class TaikoKeysTests {
        [Fact]
        public void TaikoKeysEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)TaikoKeys.None);
            Assert.Equal(1 << 0, (int)TaikoKeys.LeftRed);
            Assert.Equal(1 << 1, (int)TaikoKeys.LeftBlue);
            Assert.Equal(1 << 2, (int)TaikoKeys.RightRed);
            Assert.Equal(1 << 3, (int)TaikoKeys.RightBlue);
        }
    }
}

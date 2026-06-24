using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Tests.Enums {
    public class OsuKeysTests {
        [Fact]
        public void OsuKeysEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)OsuKeys.None);
            Assert.Equal(1 << 0, (int)OsuKeys.M1);
            Assert.Equal(1 << 1, (int)OsuKeys.M2);
            Assert.Equal((1 << 2) + (int)OsuKeys.M1, (int)OsuKeys.K1);
            Assert.Equal((1 << 3) + (int)OsuKeys.M2, (int)OsuKeys.K2);
            Assert.Equal(1 << 4, (int)OsuKeys.Smoke);
        }
    }
}

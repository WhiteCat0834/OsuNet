using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Tests.Enums {
    public class ManiaKeysTests {
        [Fact]
        public void ManiaKeysEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)ManiaKeys.None);
            Assert.Equal(1 << 0, (int)ManiaKeys.K1);
            Assert.Equal(1 << 1, (int)ManiaKeys.K2);
            Assert.Equal(1 << 2, (int)ManiaKeys.K3);
            Assert.Equal(1 << 3, (int)ManiaKeys.K4);
            Assert.Equal(1 << 4, (int)ManiaKeys.K5);
            Assert.Equal(1 << 5, (int)ManiaKeys.K6);
            Assert.Equal(1 << 6, (int)ManiaKeys.K7);
            Assert.Equal(1 << 7, (int)ManiaKeys.K8);
            Assert.Equal(1 << 8, (int)ManiaKeys.K9);
            Assert.Equal(1 << 9, (int)ManiaKeys.K10);
        }
    }
}

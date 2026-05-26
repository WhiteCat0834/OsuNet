using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class BeatmapModeTests {
        [Fact]
        public void BeatmapModeEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)BeatmapMode.Osu);
            Assert.Equal(1, (int)BeatmapMode.Taiko);
            Assert.Equal(2, (int)BeatmapMode.Catch);
            Assert.Equal(3, (int)BeatmapMode.Mania);
        }
    }
}

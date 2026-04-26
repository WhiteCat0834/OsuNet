using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class TeamTests {
        [Fact]
        public void TeamEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)Team.Unsupported);
            Assert.Equal(1, (int)Team.Blue);
            Assert.Equal(2, (int)Team.Red);
        }
    }
}

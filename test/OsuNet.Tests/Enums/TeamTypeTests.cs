using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class TeamTypeTests {
        [Fact]
        public void TeamTypeEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)TeamType.HeadToHead);
            Assert.Equal(1, (int)TeamType.Tag);
            Assert.Equal(2, (int)TeamType.Team);
            Assert.Equal(3, (int)TeamType.TagTeam);
        }
    }
}

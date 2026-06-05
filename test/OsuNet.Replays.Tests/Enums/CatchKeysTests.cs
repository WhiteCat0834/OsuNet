using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Tests.Enums {
    public class CatchKeysTests {
        [Fact]
        public void CatchKeysEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)CatchKeys.None);
            Assert.Equal(1, (int)CatchKeys.Dash);
        }
    }
}

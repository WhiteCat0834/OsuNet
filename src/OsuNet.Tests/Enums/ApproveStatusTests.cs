using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class ApproveStatusTests {
        [Fact]
        public void ApproveStatusEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(-2, (int)ApproveStatus.Graveyard);
            Assert.Equal(-1, (int)ApproveStatus.WIP);
            Assert.Equal(0, (int)ApproveStatus.Pending);
            Assert.Equal(1, (int)ApproveStatus.Ranked);
            Assert.Equal(2, (int)ApproveStatus.Approved);
            Assert.Equal(3, (int)ApproveStatus.Qualified);
            Assert.Equal(4, (int)ApproveStatus.Loved);
        }
    }
}

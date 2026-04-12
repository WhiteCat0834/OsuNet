using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class ScoringTests {
        [Fact]
        public void ScoringEnum_ShouldContainExpectedValues()
        {
            // Assert
            Assert.Equal(0, (int)Scoring.Score);
            Assert.Equal(1, (int)Scoring.Accuracy);
            Assert.Equal(2, (int)Scoring.Combo);
            Assert.Equal(3, (int)Scoring.ComboV2);
        }
    }
}

using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class LanguageTests {
        [Fact]
        public void LanguageEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)Language.Any);
            Assert.Equal(1, (int)Language.Unspecified);
            Assert.Equal(2, (int)Language.English);
            Assert.Equal(3, (int)Language.Japanese);
            Assert.Equal(4, (int)Language.Chinese);
            Assert.Equal(5, (int)Language.Instrumental);
            Assert.Equal(6, (int)Language.Korean);
            Assert.Equal(7, (int)Language.French);
            Assert.Equal(8, (int)Language.German);
            Assert.Equal(9, (int)Language.Swedish);
            Assert.Equal(10, (int)Language.Spanish);
            Assert.Equal(11, (int)Language.Italian);
            Assert.Equal(12, (int)Language.Russian);
            Assert.Equal(13, (int)Language.Polish);
            Assert.Equal(14, (int)Language.Other);
        }
    }
}

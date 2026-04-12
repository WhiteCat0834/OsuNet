using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class GenreTests {
        [Fact]
        public void GenreEnum_ShouldContainExpectedValues() {
            // Assert
            Assert.Equal(0, (int)Genre.Any);
            Assert.Equal(1, (int)Genre.Unspecified);
            Assert.Equal(2, (int)Genre.Videogame);
            Assert.Equal(3, (int)Genre.Anime);
            Assert.Equal(4, (int)Genre.Rock);
            Assert.Equal(5, (int)Genre.Pop);
            Assert.Equal(6, (int)Genre.Other);
            Assert.Equal(7, (int)Genre.Novelty);
            Assert.Equal(9, (int)Genre.HipHop);
            Assert.Equal(10, (int)Genre.Electronic);
            Assert.Equal(11, (int)Genre.Metal);
            Assert.Equal(12, (int)Genre.Classical);
            Assert.Equal(13, (int)Genre.Folk);
            Assert.Equal(14, (int)Genre.Jazz);
        }
    }
}

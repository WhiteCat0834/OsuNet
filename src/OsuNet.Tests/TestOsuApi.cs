using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace OsuNet.Tests {
    public class TestOsuApi {
        [Test]
        public async Task CreateOsuApiWithEmptyToken() {
            Assert.Throws<ArgumentException>(() => new OsuApi(""));
        }
    }
}

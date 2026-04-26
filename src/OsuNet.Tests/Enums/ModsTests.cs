using OsuNet.Enums;

namespace OsuNet.Tests.Enums {
    public class ModsTests {
        [Fact]
        public void LanguageEnum_ShouldContainExpectedValues() {
            Assert.Equal(0, (int)Mods.None);
            Assert.Equal(1, (int)Mods.NoFail);
            Assert.Equal(2, (int)Mods.Easy);
            Assert.Equal(4, (int)Mods.TouchDevice);
            Assert.Equal(8, (int)Mods.Hidden);
            Assert.Equal(16, (int)Mods.HardRock);
            Assert.Equal(32, (int)Mods.SuddenDeath);
            Assert.Equal(64, (int)Mods.DoubleTime);
            Assert.Equal(128, (int)Mods.Relax);
            Assert.Equal(256, (int)Mods.HalfTime);
            Assert.Equal(576, (int)Mods.Nightcore);
            Assert.Equal(1024, (int)Mods.Flashlight);
            Assert.Equal(2048, (int)Mods.Autoplay);
            Assert.Equal(4096, (int)Mods.SpunOut);
            Assert.Equal(8192, (int)Mods.Relax2);
            Assert.Equal(16416, (int)Mods.Perfect);
            Assert.Equal(32768, (int)Mods.Key4);
            Assert.Equal(65536, (int)Mods.Key5);
            Assert.Equal(131072, (int)Mods.Key6);
            Assert.Equal(262144, (int)Mods.Key7);
            Assert.Equal(524288, (int)Mods.Key8);
            Assert.Equal(1048576, (int)Mods.FadeIn);
            Assert.Equal(2097152, (int)Mods.Random);
            Assert.Equal(4194304, (int)Mods.Cinema);
            Assert.Equal(8388608, (int)Mods.Target);
            Assert.Equal(16777216, (int)Mods.Key9);
            Assert.Equal(33554432, (int)Mods.KeyCoop);
            Assert.Equal(67108864, (int)Mods.Key1);
            Assert.Equal(134217728, (int)Mods.Key3);
            Assert.Equal(268435456, (int)Mods.Key2);
            Assert.Equal(536870912, (int)Mods.ScoreV2);
            Assert.Equal(1073741824, (int)Mods.Mirror);
            Assert.Equal(Mods.Key4 | Mods.Key5 | Mods.Key6 | Mods.Key7 | Mods.Key8 | Mods.Key9 | Mods.KeyCoop | Mods.Key1 | Mods.Key3 | Mods.Key2, Mods.KeyMod);
            Assert.Equal(Mods.NoFail | Mods.Easy | Mods.Hidden | Mods.HardRock | Mods.SuddenDeath | Mods.Relax | Mods.Flashlight | Mods.SpunOut | Mods.Relax2 | Mods.FadeIn | Mods.KeyMod, Mods.FreeModAllowed);
            Assert.Equal(Mods.Hidden | Mods.HardRock | Mods.DoubleTime | Mods.Flashlight | Mods.FadeIn, Mods.ScoreIncreaseMods);
        }
    }
}

using NUnit.Framework;
using OsuNet.Enums;
using OsuNet.Models.Options;
using RichardSzalay.MockHttp;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuNet.Tests {
    public class TestGetScoresAsync {
        [Test]
        public async Task GetNonExistingScoresAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_scores*")
                    .Respond("application/json", "[]");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var scores = await api.GetScoresAsync(new GetScoresOptions { BeatmapId = 0 });

            Assert.IsEmpty(scores);
        }

        [Test]
        public async Task GetExistingScoresAsync() {
            var json = File.ReadAllText("../../../TestData/GetScoresAsync.json");
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_scores*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var score = (await api.GetScoresAsync(new GetScoresOptions { BeatmapId = 1 })).First();

            Assert.AreEqual(score.ScoreId, 112244);
            Assert.AreEqual(score.Score, 964562);
            Assert.AreEqual(score.Username, "Test");
            Assert.AreEqual(score.MaxCombo, 179);
            Assert.AreEqual(score.Count50, 0);
            Assert.AreEqual(score.Count100, 0);
            Assert.AreEqual(score.Count300, 133);
            Assert.AreEqual(score.CountMiss, 0);
            Assert.AreEqual(score.CountKatu, 0);
            Assert.AreEqual(score.CountGeki, 27);
            Assert.AreEqual(score.Perfect, true);
            Assert.AreEqual(score.EnabledMods, Mods.Flashlight | Mods.HardRock | Mods.Hidden);
            Assert.AreEqual(score.UserId, 112233);
            Assert.AreEqual(score.DateTime, new DateTime(2024, 04, 13, 13, 55, 26));
            Assert.AreEqual(score.Rank, "XH");
            Assert.AreEqual(score.PP, 383.067f);
            Assert.AreEqual(score.ReplayAvailable, true);
            Assert.AreEqual(score.GetAvatar(), "https://s.ppy.sh/a/112233");
            Assert.AreEqual(score.GetUrl(), "https://osu.ppy.sh/users/112233");
        }
    }
}

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
    public class TestGetUserRecentAsync {
        [Test]
        public async Task GetNonExistingUserRecentAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_recent*")
                    .Respond("application/json", "[]");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var res = await api.GetUserRecentAsync(new GetUserRecentOptions { User = "NonExistingUser" });

            Assert.IsEmpty(res);
        }

        [Test]
        public async Task GetExistingUserRecentAsync() {
            var json = File.ReadAllText("../../../TestData/GetUserRecentAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_recent*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var users = await api.GetUserRecentAsync(new GetUserRecentOptions { User = "TestUser" });

            Assert.AreEqual(users.Length, 1);
            Assert.AreEqual(users[0].BeatmapId, 1530797);
            Assert.AreEqual(users[0].Score, 31796060);
            Assert.AreEqual(users[0].MaxCombo, 1292);
            Assert.AreEqual(users[0].Count50, 2);
            Assert.AreEqual(users[0].Count100, 48);
            Assert.AreEqual(users[0].Count300, 763);
            Assert.AreEqual(users[0].CountMiss, 0);
            Assert.AreEqual(users[0].CountKatu, 17);
            Assert.AreEqual(users[0].CountGeki, 151);
            Assert.AreEqual(users[0].Perfect, false);
            Assert.AreEqual(users[0].EnabledMods, Mods.None);
            Assert.AreEqual(users[0].UserId, 225511);
            Assert.AreEqual(users[0].DateTime, new DateTime(2026, 01, 10, 16, 09, 14));
            Assert.AreEqual(users[0].Rank, "F");
            Assert.AreEqual(users[0].ScoreId, null);
        }

        [Test]
        public async Task GetUserAsync_GetAvatar() {
            var json = File.ReadAllText("../../../TestData/GetUserRecentAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_recent*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var user = (await api.GetUserRecentAsync(new GetUserRecentOptions { User = "TestUser" })).First();

            Assert.AreEqual(user.GetAvatar(), "http://s.ppy.sh/a/225511");
        }

        [Test]
        public async Task GetUserAsync_GetUrl() {
            var json = File.ReadAllText("../../../TestData/GetUserRecentAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_recent*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var user = (await api.GetUserRecentAsync(new GetUserRecentOptions { User = "TestUser" })).First();

            Assert.AreEqual(user.GetUrl(), "https://osu.ppy.sh/users/225511");
        }
    }
}

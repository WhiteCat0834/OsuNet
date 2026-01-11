using NUnit.Framework;
using OsuNet.Enums;
using OsuNet.Models.Options;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OsuNet.Tests {
    public class TestGetUserBestAsync {
        [Test]
        public async Task GetNonExistingUserBestAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_best*")
                    .Respond("application/json", "[]");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var res = await api.GetUserBestAsync(new GetUserBestOptions { User = "NonExistingUser" });

            Assert.IsEmpty(res);
        }

        [Test]
        public async Task GetExistingUserBestAsync() {
            var json = File.ReadAllText("../../../TestData/GetUserBestAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_best*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var res = await api.GetUserBestAsync(new GetUserBestOptions { User = "TestUser" });

            Assert.AreEqual(res[0].BeatmapId, 5047712);
            Assert.AreEqual(res[0].ScoreId, 665544);
            Assert.AreEqual(res[0].Score, 89731914);
            Assert.AreEqual(res[0].MaxCombo, 1829);
            Assert.AreEqual(res[0].Count50, 0);
            Assert.AreEqual(res[0].Count100, 22);
            Assert.AreEqual(res[0].Count300, 1962);
            Assert.AreEqual(res[0].CountMiss, 1);
            Assert.AreEqual(res[0].CountKatu, 22);
            Assert.AreEqual(res[0].CountGeki, 525);
            Assert.AreEqual(res[0].Perfect, false);
            Assert.AreEqual(res[0].EnabledMods, Mods.DoubleTime | Mods.Hidden);
            Assert.AreEqual(res[0].UserId, 9999999);
            Assert.AreEqual(res[0].DateTime, new DateTime(2025, 04, 26, 15, 54, 03));
            Assert.AreEqual(res[0].Rank, "A");
            Assert.AreEqual(res[0].PP, 1807.26f);
            Assert.AreEqual(res[0].ReplayAvailable, true);
        }

        [Test]
        public async Task GetUserAsync_GetAvatar() {
            var json = File.ReadAllText("../../../TestData/GetUserBestAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_best*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var user = (await api.GetUserBestAsync(new GetUserBestOptions { User = "TestUser" })).First();

            Assert.AreEqual(user.GetAvatar(), "http://s.ppy.sh/a/9999999");
        }

        [Test]
        public async Task GetUserAsync_GetUrl() {
            var json = File.ReadAllText("../../../TestData/GetUserBestAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user_best*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var user = (await api.GetUserBestAsync(new GetUserBestOptions { User = "TestUser" })).First();

            Assert.AreEqual(user.GetUrl(), "https://osu.ppy.sh/users/9999999");
        }
    }
}
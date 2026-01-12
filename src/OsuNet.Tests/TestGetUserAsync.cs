using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using OsuNet.Models.Options;
using RichardSzalay.MockHttp;

namespace OsuNet.Tests {
	public class TestGetUserAsync {
        [Test]
        public async Task GetNonExistingUserAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user*")
                    .Respond("application/json", "[]");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var users = await api.GetUserAsync(new GetUserOptions { User = "NonExistingUser" });

            Assert.IsEmpty(users);
        }

        [Test]
        public async Task GetExistingUserAsync() {
            var json = File.ReadAllText("../../../TestData/GetUserAsync.json");

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_user*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var user = (await api.GetUserAsync(new GetUserOptions { User = "TestUser" })).First();

            Assert.AreEqual(user.UserId, 1);
            Assert.AreEqual(user.Username, "TestUser");
            Assert.AreEqual(user.JoinDate, new DateTime(2012, 01, 01, 00, 00, 00));
            Assert.AreEqual(user.Count300, 59217778);
            Assert.AreEqual(user.Count100, 5282321);
            Assert.AreEqual(user.Count50, 533948);
            Assert.AreEqual(user.PlayCount, 229370);
            Assert.AreEqual(user.RankedScore, 136752036074);
            Assert.AreEqual(user.TotalScore, 906920445086);
            Assert.AreEqual(user.PPRank, 1);
            Assert.AreEqual(user.Level, 108.8f);
            Assert.AreEqual(user.PPRaw, 31811.7f);
            Assert.AreEqual(user.Accuracy, 98.231201171875f);
            Assert.AreEqual(user.CountRankSS, 30);
            Assert.AreEqual(user.CountRankSSH, 46);
            Assert.AreEqual(user.CountRankS, 295);
            Assert.AreEqual(user.CountRankSH, 1383);
            Assert.AreEqual(user.CountRankA, 2308);
            Assert.AreEqual(user.Country, "US");
            Assert.AreEqual(user.TotalSecondsPlayed, 99999999);
            Assert.AreEqual(user.PPCountryRank, 1);
            Assert.IsEmpty(user.Events);
            Assert.AreEqual(user.GetAvatar(), "http://s.ppy.sh/a/1");
            Assert.AreEqual(user.GetUrl(), "https://osu.ppy.sh/users/1");
        }
    }
}
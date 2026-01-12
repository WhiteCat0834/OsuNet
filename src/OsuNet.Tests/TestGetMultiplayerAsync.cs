using NUnit.Framework;
using OsuNet.Enums;
using OsuNet.Models.Options;
using RichardSzalay.MockHttp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuNet.Tests {
    public class TestGetMultiplayerAsync {
        [Test]
        public async Task GetNonExistingMultiplayerAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_match*")
                    .Respond("application/json", "{\"match\":0,\"games\":[]}");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var match = await api.GetMultiplayerAsync(new GetMultiplayerOptions { MatchId = 1 });

            Assert.AreEqual(match.Match.MatchId, 0);
            Assert.AreEqual(match.Match.Name, null);
            Assert.AreEqual(match.Match.StartTime, new DateTime(0001, 01, 01, 00, 00, 00));
            Assert.AreEqual(match.Match.EndTime, null);
            Assert.IsEmpty(match.Games);
        }

        [Test]
        public async Task GetExistingMultiplayerAsync() {
            var json = File.ReadAllText("../../../TestData/GetMultiplayerAsync.json");
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_match*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var match = await api.GetMultiplayerAsync(new GetMultiplayerOptions { MatchId = 120285014 });

            Assert.AreEqual(match.Match.MatchId, 120285014);
            Assert.AreEqual(match.Match.Name, "game");
            Assert.AreEqual(match.Match.StartTime, new DateTime(2026, 01, 11, 05, 38, 55));
            Assert.AreEqual(match.Match.EndTime, new DateTime(2026, 01, 11, 05, 52, 28));

            Assert.AreEqual(match.Games.Length, 1);
            Assert.AreEqual(match.Games[0].GameId, 631404958);
            Assert.AreEqual(match.Games[0].StartTime, new DateTime(2026, 01, 11, 05, 40, 17));
            Assert.AreEqual(match.Games[0].EndTime, new DateTime(2026, 01, 11, 05, 42, 04));
            Assert.AreEqual(match.Games[0].BeatmapId, 4754210);
            Assert.AreEqual(match.Games[0].PlayMode, BeatmapMode.Osu);
            Assert.AreEqual(match.Games[0].MatchType, null);
            Assert.AreEqual(match.Games[0].ScoringType, Scoring.Score);
            Assert.AreEqual(match.Games[0].TeamType, TeamType.HeadToHead);
            Assert.AreEqual(match.Games[0].Mods, Mods.None);
            Assert.AreEqual(match.Games[0].Mods, Mods.None);

            Assert.AreEqual(match.Games[0].Scores.Length, 1);
            Assert.AreEqual(match.Games[0].Scores[0].Slot, 0);
            Assert.AreEqual(match.Games[0].Scores[0].Team, Team.Unsupported);
            Assert.AreEqual(match.Games[0].Scores[0].UserId, 14125274);
            Assert.AreEqual(match.Games[0].Scores[0].Score, 143282);
            Assert.AreEqual(match.Games[0].Scores[0].MaxCombo, 54);
            Assert.AreEqual(match.Games[0].Scores[0].Rank, "0");
            Assert.AreEqual(match.Games[0].Scores[0].Count50, 17);
            Assert.AreEqual(match.Games[0].Scores[0].Count100, 79);
            Assert.AreEqual(match.Games[0].Scores[0].Count300, 141);
            Assert.AreEqual(match.Games[0].Scores[0].CountMiss, 43);
            Assert.AreEqual(match.Games[0].Scores[0].CountGeki, 12);
            Assert.AreEqual(match.Games[0].Scores[0].CountKatu, 21);
            Assert.AreEqual(match.Games[0].Scores[0].Perfect, false);
            Assert.AreEqual(match.Games[0].Scores[0].Pass, true);
            Assert.AreEqual(match.Games[0].Scores[0].EnabledMods, null);
            Assert.AreEqual(match.Games[0].Scores[0].GetAvatar(), "http://s.ppy.sh/a/14125274");
            Assert.AreEqual(match.Games[0].Scores[0].GetUrl(), "https://osu.ppy.sh/users/14125274");
        }
    }
}

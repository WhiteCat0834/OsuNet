using NUnit.Framework;
using OsuNet.Models.Options;
using RichardSzalay.MockHttp;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuNet.Tests
{
    public class TestGetReplayAsync
    {
        [Test]
        public async Task GetNonExistingReplayAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_replay*")
                    .Respond("application/json", "{\"error\":\"Replay not available.\"}");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var replay = await api.GetReplayAsync(new GetReplayOptions { BeatmapId = 0, User = "TestUser" });

            Assert.AreEqual(replay.Content, null);
            Assert.AreEqual(replay.Encoding, null);
        }

        [Test]
        public async Task GetExistingReplayAsync() {
            var json = File.ReadAllText("../../../TestData/GetReplayAsync.json");
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_replay*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var replay = await api.GetReplayAsync(new GetReplayOptions { BeatmapId = 0, User = "TestUser" });

            Assert.AreEqual(replay.Content, "BBSBasdzxv...gfnhkliuty");
            Assert.AreEqual(replay.Encoding, "base64");
        }
    }
}

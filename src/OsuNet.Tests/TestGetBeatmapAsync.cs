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
    public class TestGetBeatmapAsync {
        [Test]
        public async Task GetNonExistingBeatmapAsync() {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_beatmaps*")
                    .Respond("application/json", "[]");

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var beatmaps = await api.GetBeatmapAsync(new GetBeatmapOptions { BeatmapId = 0 });

            Assert.IsEmpty(beatmaps);
        }

        [Test]
        public async Task GetExistingBeatmapAsync() {
            var json = File.ReadAllText("../../../TestData/GetBeatmapsAsync.json");
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://osu.ppy.sh/api/get_beatmaps*")
                    .Respond("application/json", json);

            var api = new OsuApi("token", new HttpClient(mockHttp));
            var beatmap = (await api.GetBeatmapAsync(new GetBeatmapOptions { BeatmapId = 2233440 })).First();

            Assert.AreEqual(beatmap.BeatmapSetId, 5544332);
            Assert.AreEqual(beatmap.BeatmapId, 2233440);
            Assert.AreEqual(beatmap.Approved, ApproveStatus.WIP);
            Assert.AreEqual(beatmap.TotalLength, 93);
            Assert.AreEqual(beatmap.HitLength, 85);
            Assert.AreEqual(beatmap.Version, "expert");
            Assert.AreEqual(beatmap.FileMD5, "a86730658c7cf0cd13941db74dfbaa3f");
            Assert.AreEqual(beatmap.DiffSize, 4.3f);
            Assert.AreEqual(beatmap.DiffOverall, 8.7f);
            Assert.AreEqual(beatmap.DiffApproach, 9.4f);
            Assert.AreEqual(beatmap.DiffDrain, 6.3f);
            Assert.AreEqual(beatmap.Mode, BeatmapMode.Osu);
            Assert.AreEqual(beatmap.CountNormal, 198);
            Assert.AreEqual(beatmap.CountSlider, 126);
            Assert.AreEqual(beatmap.CountSpinner, 0);
            Assert.AreEqual(beatmap.SubmitDate, new DateTime(2026, 01, 09, 16, 53, 18));
            Assert.AreEqual(beatmap.ApprovedDate, null);
            Assert.AreEqual(beatmap.LastUpdate, new DateTime(2026, 01, 10, 22, 56, 07));
            Assert.AreEqual(beatmap.Artist, "artistTest");
            Assert.AreEqual(beatmap.ArtistUnicode, "artistTest");
            Assert.AreEqual(beatmap.Title, "Test");
            Assert.AreEqual(beatmap.TitleUnicode, "Test");
            Assert.AreEqual(beatmap.Creator, "creatorTest");
            Assert.AreEqual(beatmap.CreatorId, 11111111);
            Assert.AreEqual(beatmap.BPM, 195);
            Assert.AreEqual(beatmap.Source, "");
            Assert.AreEqual(beatmap.Tags, "");
            Assert.AreEqual(beatmap.GenreId, Genre.Unspecified);
            Assert.AreEqual(beatmap.LanguageId, Language.Unspecified);
            Assert.AreEqual(beatmap.FavouriteCount, 0);
            Assert.AreEqual(beatmap.Rating, 0);
            Assert.AreEqual(beatmap.Storyboard, false);
            Assert.AreEqual(beatmap.Video, false);
            Assert.AreEqual(beatmap.DownloadUnavailable, false);
            Assert.AreEqual(beatmap.AudioUnavailble, false);
            Assert.AreEqual(beatmap.PlayCount, 0);
            Assert.AreEqual(beatmap.PassCount, 0);
            Assert.AreEqual(beatmap.Packs, null);
            Assert.AreEqual(beatmap.MaxCombo, 502);
            Assert.AreEqual(beatmap.DiffAim, null);
            Assert.AreEqual(beatmap.DiffSpeed, null);
            Assert.AreEqual(beatmap.DiffecultyRating, 5.5707f);
            Assert.AreEqual(beatmap.GetCover(), "https://assets.ppy.sh/beatmaps/5544332/covers/cover.jpg");
            Assert.AreEqual(beatmap.GetThumbnail(), "https://b.ppy.sh/thumb/5544332l.jpg");
            Assert.AreEqual(beatmap.GetCreatorUrl(), "https://osu.ppy.sh/users/11111111");
            Assert.AreEqual(beatmap.GetCreatorAvatar(), "https://s.ppy.sh/a/11111111");
            Assert.AreEqual(beatmap.GetUrl(), "https://osu.ppy.sh/beatmapsets/5544332#osu/2233440");
        }
    }
}

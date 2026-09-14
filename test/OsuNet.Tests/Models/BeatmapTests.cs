using Newtonsoft.Json;
using OsuNet.Enums;
using OsuNet.Models;

namespace OsuNet.Tests.Models {
    public class BeatmapTests {
        [Fact]
        public void Beatmap_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var beatmap = new Beatmap(
                BeatmapSetId: 12345,
                BeatmapId: 67890,
                Approved: ApproveStatus.Ranked,
                TotalLength: 300,
                HitLength: 250,
                Version: "Hard",
                FileMD5: "abcdef1234567890",
                DiffSize: 4.0f,
                DiffOverall: 5.5f,
                DiffApproach: 4.5f,
                DiffDrain: 3.5f,
                Mode: BeatmapMode.Osu,
                CountNormal: 100,
                CountSlider: 50,
                CountSpinner: 5,
                SubmitDate: DateTime.UtcNow,
                ApprovedDate: DateTime.UtcNow,
                LastUpdate: DateTime.UtcNow,
                Artist: "Artist Name",
                ArtistUnicode: "アーティスト名",
                Title: "Song Title",
                TitleUnicode: "曲のタイトル",
                Creator: "Creator Name",
                CreatorId: 54321,
                BPM: 180.0f,
                Source: "",
                Tags: "",
                GenreId: Genre.Pop,
                LanguageId: Language.English,
                FavouriteCount: 0,
                Rating: 0f,
                Storyboard: false,
                Video: false,
                DownloadUnavailable: false,
                AudioUnavailable: true,
                PlayCount: 0,
                PassCount: 0,
                Packs: "",
                MaxCombo: 500,
                DiffAim: 5.0f,
                DiffSpeed: 100.0f,
                DifficultyRating: 6.0f
            );

            // Act
            var json = JsonConvert.SerializeObject(beatmap);
            var deserializedBeatmap = JsonConvert.DeserializeObject<Beatmap>(json);

            // Assert
            Assert.NotNull(deserializedBeatmap);
            Assert.Equal(beatmap.BeatmapSetId, deserializedBeatmap.BeatmapSetId);
            Assert.Equal(beatmap.BeatmapId, deserializedBeatmap.BeatmapId);
            Assert.Equal(beatmap.Approved, deserializedBeatmap.Approved);
            Assert.Equal(beatmap.TotalLength, deserializedBeatmap.TotalLength);
            Assert.Equal(beatmap.HitLength, deserializedBeatmap.HitLength);
            Assert.Equal(beatmap.Version, deserializedBeatmap.Version);
            Assert.Equal(beatmap.ApprovedDate, deserializedBeatmap.ApprovedDate);
            Assert.Equal(beatmap.Artist, deserializedBeatmap.Artist);
            Assert.Equal(beatmap.ArtistUnicode, deserializedBeatmap.ArtistUnicode);
            Assert.Equal(beatmap.AudioUnavailable, deserializedBeatmap.AudioUnavailable);
            Assert.Equal(beatmap.DiffAim, deserializedBeatmap.DiffAim);
            Assert.Equal(beatmap.DiffApproach, deserializedBeatmap.DiffApproach);
            Assert.Equal(beatmap.DiffOverall, deserializedBeatmap.DiffOverall);
            Assert.Equal(beatmap.BPM, deserializedBeatmap.BPM);
            Assert.Equal(beatmap.Creator, deserializedBeatmap.Creator);
            Assert.Equal(beatmap.CreatorId, deserializedBeatmap.CreatorId);
            Assert.Equal(beatmap.CountNormal, deserializedBeatmap.CountNormal);
            Assert.Equal(beatmap.CountSlider, deserializedBeatmap.CountSlider);
            Assert.Equal(beatmap.CountSpinner, deserializedBeatmap.CountSpinner);
            Assert.Equal(beatmap.DiffSize, deserializedBeatmap.DiffSize);
            Assert.Equal(beatmap.DiffDrain, deserializedBeatmap.DiffDrain);
            Assert.Equal(beatmap.DifficultyRating, deserializedBeatmap.DifficultyRating);
            Assert.Equal(beatmap.DiffSpeed, deserializedBeatmap.DiffSpeed);
            Assert.Equal(beatmap.DownloadUnavailable, deserializedBeatmap.DownloadUnavailable);
            Assert.Equal(beatmap.FavouriteCount, deserializedBeatmap.FavouriteCount);
            Assert.Equal(beatmap.FileMD5, deserializedBeatmap.FileMD5);
            Assert.Equal(beatmap.GenreId, deserializedBeatmap.GenreId);
            Assert.Equal(beatmap.LanguageId, deserializedBeatmap.LanguageId);
            Assert.Equal(beatmap.LastUpdate, deserializedBeatmap.LastUpdate);
            Assert.Equal(beatmap.MaxCombo, deserializedBeatmap.MaxCombo);
            Assert.Equal(beatmap.Video, deserializedBeatmap.Video);
            Assert.Equal(beatmap.Mode, deserializedBeatmap.Mode);
            Assert.Equal(beatmap.Packs, deserializedBeatmap.Packs);
            Assert.Equal(beatmap.PassCount, deserializedBeatmap.PassCount);
            Assert.Equal(beatmap.PlayCount, deserializedBeatmap.PlayCount);
            Assert.Equal(beatmap.Rating, deserializedBeatmap.Rating);
            Assert.Equal(beatmap.Source, deserializedBeatmap.Source);
            Assert.Equal(beatmap.Storyboard, deserializedBeatmap.Storyboard);
            Assert.Equal(beatmap.SubmitDate, deserializedBeatmap.SubmitDate);
            Assert.Equal(beatmap.Tags, deserializedBeatmap.Tags);
            Assert.Equal(beatmap.Title, deserializedBeatmap.Title);
            Assert.Equal(beatmap.TitleUnicode, deserializedBeatmap.TitleUnicode);
            Assert.Equal(beatmap.GetCover(), deserializedBeatmap.GetCover());
            Assert.Equal(beatmap.GetThumbnail(), deserializedBeatmap.GetThumbnail());
            Assert.Equal(beatmap.GetCreatorUrl(), deserializedBeatmap.GetCreatorUrl());
            Assert.Equal(beatmap.GetCreatorAvatar(), deserializedBeatmap.GetCreatorAvatar());
            Assert.Equal(beatmap.GetUrl(), deserializedBeatmap.GetUrl());
            Assert.Equal($"https://assets.ppy.sh/beatmaps/{beatmap.BeatmapSetId}/covers/cover.jpg", deserializedBeatmap.GetCover());
            Assert.Equal($"https://b.ppy.sh/thumb/{beatmap.BeatmapSetId}l.jpg", deserializedBeatmap.GetThumbnail());
            Assert.Equal($"https://osu.ppy.sh/users/{beatmap.CreatorId}", deserializedBeatmap.GetCreatorUrl());
            Assert.Equal($"https://s.ppy.sh/a/{beatmap.CreatorId}", deserializedBeatmap.GetCreatorAvatar());
            Assert.Equal($"https://osu.ppy.sh/beatmapsets/{beatmap.BeatmapSetId}#{beatmap.Mode.ToString().ToLower()}/{beatmap.BeatmapId}", deserializedBeatmap.GetUrl());
        }
    }
}
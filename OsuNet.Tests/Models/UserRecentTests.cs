using Newtonsoft.Json;
using OsuNet.Enums;
using OsuNet.Models;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace OsuNet.Tests.Models {
    public class UserRecentTests {
        [Fact]
        public void UserRecent_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var userRecent = new UserRecent {
                BeatmapId = 12345,
                ScoreId = 67890,
                TotalScore = 98765,
                MaxCombo = 500,
                Count50 = 50,
                Count100 = 50,
                Count300 = 300,
                CountMiss = 10,
                CountGeki = 10,
                CountKatu = 5,
                IsPerfect = true,
                DateTime = DateTime.UtcNow,
                EnabledMods = Mods.HardRock | Mods.Flashlight,
                UserId = 54321,
                Rank = "F"
            };

            // Act
            var json = JsonConvert.SerializeObject(userRecent);
            var deserializedUserRecent = JsonConvert.DeserializeObject<UserRecent>(json);

            // Assert
            Assert.NotNull(deserializedUserRecent);
            Assert.Equal(userRecent.BeatmapId, deserializedUserRecent.BeatmapId);
            Assert.Equal(userRecent.ScoreId, deserializedUserRecent.ScoreId);
            Assert.Equal(userRecent.TotalScore, deserializedUserRecent.TotalScore);
            Assert.Equal(userRecent.MaxCombo, deserializedUserRecent.MaxCombo);
            Assert.Equal(userRecent.Count50, deserializedUserRecent.Count50);
            Assert.Equal(userRecent.Count100, deserializedUserRecent.Count100);
            Assert.Equal(userRecent.Count300, deserializedUserRecent.Count300);
            Assert.Equal(userRecent.CountMiss, deserializedUserRecent.CountMiss);
            Assert.Equal(userRecent.CountGeki, deserializedUserRecent.CountGeki);
            Assert.Equal(userRecent.CountKatu, deserializedUserRecent.CountKatu);
            Assert.Equal(userRecent.IsPerfect, deserializedUserRecent.IsPerfect);
            Assert.Equal(userRecent.EnabledMods, deserializedUserRecent.EnabledMods);
            Assert.Equal(userRecent.UserId, deserializedUserRecent.UserId);
            Assert.Equal(userRecent.DateTime, deserializedUserRecent.DateTime);
            Assert.Equal(userRecent.Rank, deserializedUserRecent.Rank);
            Assert.Equal(userRecent.GetAvatar(), deserializedUserRecent.GetAvatar());
            Assert.Equal(userRecent.GetUrl(), deserializedUserRecent.GetUrl());
            Assert.Equal($"https://s.ppy.sh/a/{userRecent.UserId}", deserializedUserRecent.GetAvatar());
            Assert.Equal($"https://osu.ppy.sh/users/{userRecent.UserId}", deserializedUserRecent.GetUrl());
        }
    }
}
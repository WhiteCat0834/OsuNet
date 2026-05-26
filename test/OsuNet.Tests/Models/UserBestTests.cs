using Newtonsoft.Json;
using OsuNet.Enums;
using OsuNet.Models;

namespace OsuNet.Tests.Models {
    public class UserBestTests {
        [Fact]
        public void UserBest_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var userBest = new UserBest {
                BeatmapId = 12345,
                ScoreId = 67890,
                TotalScore = 98765,
                MaxCombo = 500,
                Count50 = 50,
                Count100 = 100,
                Count300 = 300,
                CountKatu = 20,
                CountGeki = 10,
                CountMiss = 5,
                PP = 10,
                ReplayAvailable = true,
                DateTime = DateTime.UtcNow,
                EnabledMods = Mods.NoFail | Mods.Nightcore,
                IsPerfect = false,
                Rank = "S",
                UserId = 54321
            };

            // Act
            var json = JsonConvert.SerializeObject(userBest);
            var deserializedUserBest = JsonConvert.DeserializeObject<UserBest>(json);

            // Assert
            Assert.NotNull(deserializedUserBest);
            Assert.Equal(userBest.BeatmapId, deserializedUserBest.BeatmapId);
            Assert.Equal(userBest.ScoreId, deserializedUserBest.ScoreId);
            Assert.Equal(userBest.TotalScore, deserializedUserBest.TotalScore);
            Assert.Equal(userBest.MaxCombo, deserializedUserBest.MaxCombo);
            Assert.Equal(userBest.Count50, deserializedUserBest.Count50);
            Assert.Equal(userBest.Count100, deserializedUserBest.Count100);
            Assert.Equal(userBest.Count300, deserializedUserBest.Count300);
            Assert.Equal(userBest.CountKatu, deserializedUserBest.CountKatu);
            Assert.Equal(userBest.CountGeki, deserializedUserBest.CountGeki);
            Assert.Equal(userBest.CountMiss, deserializedUserBest.CountMiss);
            Assert.Equal(userBest.PP, deserializedUserBest.PP);
            Assert.Equal(userBest.ReplayAvailable, deserializedUserBest.ReplayAvailable);
            Assert.Equal(userBest.DateTime, deserializedUserBest.DateTime);
            Assert.Equal(userBest.EnabledMods, deserializedUserBest.EnabledMods);
            Assert.Equal(userBest.IsPerfect, deserializedUserBest.IsPerfect);
            Assert.Equal(userBest.Rank, deserializedUserBest.Rank);
            Assert.Equal(userBest.UserId, deserializedUserBest.UserId);
            Assert.Equal($"https://s.ppy.sh/a/{userBest.UserId}", deserializedUserBest.GetAvatar());
            Assert.Equal($"https://osu.ppy.sh/users/{userBest.UserId}", deserializedUserBest.GetUrl());
        }
    }
}
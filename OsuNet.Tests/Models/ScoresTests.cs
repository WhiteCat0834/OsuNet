using Newtonsoft.Json;
using OsuNet.Enums;
using OsuNet.Models;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace OsuNet.Tests.Models {
    public class ScoresTests {
        [Fact]
        public void Scores_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var score = new Score {
                ScoreId = 12345,
                TotalScore = 98765,
                Username = "TestUser",
                Count300 = 1000,
                Count100 = 500,
                Count50 = 200,
                CountMiss = 10,
                CountGeki = 10,
                CountKatu = 5,
                MaxCombo = 300,
                DateTime = DateTime.UtcNow,
                UserId = 67890,
                ReplayAvailable = false,
                EnabledMods = Mods.HardRock,
                IsPerfect = false,
                PP = 250.5f,
                Rank = "A"
            };

            // Act
            var json = JsonConvert.SerializeObject(score);
            var deserializedScore = JsonConvert.DeserializeObject<Score>(json);

            // Assert
            Assert.NotNull(deserializedScore);
            Assert.Equal(score.ScoreId, deserializedScore.ScoreId);
            Assert.Equal(score.TotalScore, deserializedScore.TotalScore);
            Assert.Equal(score.Username, deserializedScore.Username);
            Assert.Equal(score.Count300, deserializedScore.Count300);
            Assert.Equal(score.Count100, deserializedScore.Count100);
            Assert.Equal(score.Count50, deserializedScore.Count50);
            Assert.Equal(score.CountMiss, deserializedScore.CountMiss);
            Assert.Equal(score.CountGeki, deserializedScore.CountGeki);
            Assert.Equal(score.CountKatu, deserializedScore.CountKatu);
            Assert.Equal(score.MaxCombo, deserializedScore.MaxCombo);
            Assert.Equal(score.DateTime, deserializedScore.DateTime);
            Assert.Equal(score.UserId, deserializedScore.UserId);
            Assert.Equal(score.ReplayAvailable, deserializedScore.ReplayAvailable);
            Assert.Equal(score.EnabledMods, deserializedScore.EnabledMods);
            Assert.Equal(score.IsPerfect, deserializedScore.IsPerfect);
            Assert.Equal(score.PP, deserializedScore.PP);
            Assert.Equal(score.Rank, deserializedScore.Rank);
            Assert.Equal(score.GetAvatar(), deserializedScore.GetAvatar());
            Assert.Equal(score.GetUrl(), deserializedScore.GetUrl());
            Assert.Equal($"https://s.ppy.sh/a/{score.UserId}", deserializedScore.GetAvatar());
            Assert.Equal($"https://osu.ppy.sh/users/{score.UserId}", deserializedScore.GetUrl());
        }
    }
}
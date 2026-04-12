using Newtonsoft.Json;
using OsuNet.Models.Info;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Info {
    public class ScoreInfoTests {
        [Fact]
        public void ScoreInfo_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var scoreInfo = new ScoreInfo {
                Slot = 1,
                Team = Team.Blue,
                UserId = 12345,
                TotalScore = 98765,
                MaxCombo = 500,
                Count300 = 300,
                Count100 = 100,
                Count50 = 50,
                CountMiss = 5,
                CountGeki = 5,
                CountKatu = 5,
                IsPerfect = true,
                Pass = true,
                EnabledMods = Mods.HardRock | Mods.DoubleTime,
                Rank = "A"
            };

            // Act
            var json = JsonConvert.SerializeObject(scoreInfo);
            var deserializedScoreInfo = JsonConvert.DeserializeObject<ScoreInfo>(json);

            // Assert
            Assert.NotNull(deserializedScoreInfo);
            Assert.Equal(scoreInfo.Slot, deserializedScoreInfo.Slot);
            Assert.Equal(scoreInfo.Team, deserializedScoreInfo.Team);
            Assert.Equal(scoreInfo.UserId, deserializedScoreInfo.UserId);
            Assert.Equal(scoreInfo.TotalScore, deserializedScoreInfo.TotalScore);
            Assert.Equal(scoreInfo.MaxCombo, deserializedScoreInfo.MaxCombo);
            Assert.Equal(scoreInfo.Count300, deserializedScoreInfo.Count300);
            Assert.Equal(scoreInfo.Count100, deserializedScoreInfo.Count100);
            Assert.Equal(scoreInfo.Count50, deserializedScoreInfo.Count50);
            Assert.Equal(scoreInfo.CountMiss, deserializedScoreInfo.CountMiss);
            Assert.Equal(scoreInfo.CountGeki, deserializedScoreInfo.CountGeki);
            Assert.Equal(scoreInfo.CountKatu, deserializedScoreInfo.CountKatu);
            Assert.Equal(scoreInfo.IsPerfect, deserializedScoreInfo.IsPerfect);
            Assert.Equal(scoreInfo.Pass, deserializedScoreInfo.Pass);
            Assert.Equal(scoreInfo.EnabledMods, deserializedScoreInfo.EnabledMods);
            Assert.Equal(scoreInfo.Rank, deserializedScoreInfo.Rank);
            Assert.Equal(scoreInfo.GetAvatar(), deserializedScoreInfo.GetAvatar());
            Assert.Equal(scoreInfo.GetUrl(), deserializedScoreInfo.GetUrl());
        }
    }
}
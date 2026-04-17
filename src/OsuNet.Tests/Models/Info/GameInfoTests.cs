using Newtonsoft.Json;
using OsuNet.Models.Info;
using OsuNet.Enums;

namespace OsuNet.Tests.Models.Info
{
    public class GameInfoTests
    {
        [Fact]
        public void GameInfo_ShouldSerializeAndDeserializeCorrectly()
        {
            // Arrange
            var gameInfo = new GameInfo
            {
                GameId = 123,
                StartTime = new DateTime(2023, 1, 1),
                EndTime = new DateTime(2023, 1, 2),
                BeatmapId = 456,
                PlayMode = BeatmapMode.Osu,
                MatchType = "Osu",
                ScoringType = Scoring.Score,
                TeamType = TeamType.HeadToHead,
                Mods = Mods.Hidden | Mods.HardRock,
                Scores = new[] {
                    new ScoreInfo {
                        UserId = 789,
                        TotalScore = 1000000,
                        MaxCombo = 500,
                        Count300 = 300,
                        Count100 = 50,
                        Count50 = 10,
                        CountMiss = 5,
                        IsPerfect = false,
                        EnabledMods = Mods.Hidden
                    }
                }
            };

            // Act
            var json = JsonConvert.SerializeObject(gameInfo);
            var deserializedGameInfo = JsonConvert.DeserializeObject<GameInfo>(json);

            // Assert
            Assert.NotNull(deserializedGameInfo);
            Assert.Equal(gameInfo.GameId, deserializedGameInfo.GameId);
            Assert.Equal(gameInfo.StartTime, deserializedGameInfo.StartTime);
            Assert.Equal(gameInfo.EndTime, deserializedGameInfo.EndTime);
            Assert.Equal(gameInfo.BeatmapId, deserializedGameInfo.BeatmapId);
            Assert.Equal(gameInfo.PlayMode, deserializedGameInfo.PlayMode);
            Assert.Equal(gameInfo.MatchType, deserializedGameInfo.MatchType);
            Assert.Equal(gameInfo.ScoringType, deserializedGameInfo.ScoringType);
            Assert.Equal(gameInfo.TeamType, deserializedGameInfo.TeamType);
            Assert.Equal(gameInfo.Mods, deserializedGameInfo.Mods);
            Assert.NotNull(deserializedGameInfo.Scores);
            Assert.Single(deserializedGameInfo.Scores);
            Assert.Equal(gameInfo.Scores[0].UserId, deserializedGameInfo.Scores[0].UserId);
            Assert.Equal(gameInfo.Scores[0].TotalScore, deserializedGameInfo.Scores[0].TotalScore);
            Assert.Equal(gameInfo.Scores[0].MaxCombo, deserializedGameInfo.Scores[0].MaxCombo);
            Assert.Equal(gameInfo.Scores[0].Count300, deserializedGameInfo.Scores[0].Count300);
            Assert.Equal(gameInfo.Scores[0].Count100, deserializedGameInfo.Scores[0].Count100);
            Assert.Equal(gameInfo.Scores[0].Count50, deserializedGameInfo.Scores[0].Count50);
            Assert.Equal(gameInfo.Scores[0].CountMiss, deserializedGameInfo.Scores[0].CountMiss);
            Assert.Equal(gameInfo.Scores[0].IsPerfect, deserializedGameInfo.Scores[0].IsPerfect);
            Assert.Equal(gameInfo.Scores[0].EnabledMods, deserializedGameInfo.Scores[0].EnabledMods);
        }
    }
}
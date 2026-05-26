using Newtonsoft.Json;
using OsuNet.Enums;
using OsuNet.Models;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models {
    public class MatchTests {
        [Fact]
        public void Match_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var match = new Match {
                MatchInfo = new MatchInfo {
                    MatchId = 1,
                    Name = "Test Match",
                    StartTime = new DateTime(2023, 1, 1),
                    EndTime = new DateTime(2023, 1, 2)
                },
                Games = new[] {
                    new GameInfo {
                        GameId = 789,
                        StartTime = new DateTime(2023, 1, 1),
                        EndTime = new DateTime(2023, 1, 2),
                        BeatmapId = 101112,
                        PlayMode = BeatmapMode.Osu,
                        MatchType = "Osu",
                        ScoringType = Scoring.Score,
                        TeamType = TeamType.HeadToHead,
                        Mods = Mods.Hidden | Mods.HardRock,
                        Scores = new[] {
                            new ScoreInfo {
                                UserId = 131415,
                                TotalScore = 1000000,
                                MaxCombo = 500,
                                Count300 = 300,
                                Count100 = 50,
                                Count50 = 10,
                                CountMiss = 5,
                                IsPerfect = false,
                                EnabledMods = Mods.Hidden,
                                CountGeki = 5,
                                CountKatu = 5,
                                Pass = true,
                                Rank = "SH",
                                Slot = 1,
                                Team = Team.Unsupported
                            }
                        }
                    }
                }
            };

            // Act
            var json = JsonConvert.SerializeObject(match);
            var deserializedMatch = JsonConvert.DeserializeObject<Match>(json);

            // Assert
            Assert.NotNull(deserializedMatch);
            Assert.Equal(match.MatchInfo.MatchId, deserializedMatch.MatchInfo.MatchId);
            Assert.Equal(match.MatchInfo.Name, deserializedMatch.MatchInfo.Name);
            Assert.Equal(match.MatchInfo.StartTime, deserializedMatch.MatchInfo.StartTime);
            Assert.Equal(match.MatchInfo.EndTime, deserializedMatch.MatchInfo.EndTime);
            Assert.NotNull(deserializedMatch.Games);
            Assert.Single(deserializedMatch.Games);
            Assert.Equal(match.Games[0].GameId, deserializedMatch.Games[0].GameId);
            Assert.Equal(match.Games[0].StartTime, deserializedMatch.Games[0].StartTime);
            Assert.Equal(match.Games[0].EndTime, deserializedMatch.Games[0].EndTime);
            Assert.Equal(match.Games[0].BeatmapId, deserializedMatch.Games[0].BeatmapId);
            Assert.Equal(match.Games[0].PlayMode, deserializedMatch.Games[0].PlayMode);
            Assert.Equal(match.Games[0].MatchType, deserializedMatch.Games[0].MatchType);
            Assert.Equal(match.Games[0].ScoringType, deserializedMatch.Games[0].ScoringType);
            Assert.Equal(match.Games[0].TeamType, deserializedMatch.Games[0].TeamType);
            Assert.Equal(match.Games[0].Mods, deserializedMatch.Games[0].Mods);
            Assert.NotNull(deserializedMatch.Games[0].Scores);
            Assert.Single(deserializedMatch.Games[0].Scores);
            Assert.Equal(match.Games[0].Scores[0].UserId, deserializedMatch.Games[0].Scores[0].UserId);
            Assert.Equal(match.Games[0].Scores[0].TotalScore, deserializedMatch.Games[0].Scores[0].TotalScore);
            Assert.Equal(match.Games[0].Scores[0].MaxCombo, deserializedMatch.Games[0].Scores[0].MaxCombo);
            Assert.Equal(match.Games[0].Scores[0].Count300, deserializedMatch.Games[0].Scores[0].Count300);
            Assert.Equal(match.Games[0].Scores[0].Count100, deserializedMatch.Games[0].Scores[0].Count100);
            Assert.Equal(match.Games[0].Scores[0].Count50, deserializedMatch.Games[0].Scores[0].Count50);
            Assert.Equal(match.Games[0].Scores[0].CountMiss, deserializedMatch.Games[0].Scores[0].CountMiss);
            Assert.Equal(match.Games[0].Scores[0].IsPerfect, deserializedMatch.Games[0].Scores[0].IsPerfect);
            Assert.Equal(match.Games[0].Scores[0].EnabledMods, deserializedMatch.Games[0].Scores[0].EnabledMods);
            Assert.Equal(match.Games[0].Scores[0].CountGeki, deserializedMatch.Games[0].Scores[0].CountGeki);
            Assert.Equal(match.Games[0].Scores[0].CountKatu, deserializedMatch.Games[0].Scores[0].CountKatu);
            Assert.Equal(match.Games[0].Scores[0].Pass, deserializedMatch.Games[0].Scores[0].Pass);
            Assert.Equal(match.Games[0].Scores[0].Rank, deserializedMatch.Games[0].Scores[0].Rank);
            Assert.Equal(match.Games[0].Scores[0].Slot, deserializedMatch.Games[0].Scores[0].Slot);
            Assert.Equal(match.Games[0].Scores[0].Team, deserializedMatch.Games[0].Scores[0].Team);
            Assert.Equal(match.Games[0].Scores[0].GetAvatar(), deserializedMatch.Games[0].Scores[0].GetAvatar());
            Assert.Equal(match.Games[0].Scores[0].GetUrl(), deserializedMatch.Games[0].Scores[0].GetUrl());
            Assert.Equal($"https://s.ppy.sh/a/{match.Games[0].Scores[0].UserId}", deserializedMatch.Games[0].Scores[0].GetAvatar());
            Assert.Equal($"https://osu.ppy.sh/users/{match.Games[0].Scores[0].UserId}", deserializedMatch.Games[0].Scores[0].GetUrl());
        }
    }
}

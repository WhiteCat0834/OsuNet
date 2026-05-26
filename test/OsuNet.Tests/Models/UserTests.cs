using Newtonsoft.Json;
using OsuNet.Models;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models {
    public class UserTests {
        [Fact]
        public void User_ShouldSerializeAndDeserializeCorrectly() {
            // Arrange
            var user = new User {
                UserId = 123,
                Username = "TestUser",
                Country = "US",
                JoinDate = new DateTime(2023, 1, 1),
                Count300 = 1000,
                Count100 = 500,
                Count50 = 200,
                RankedScore = 1000000,
                TotalScore = 5000000,
                Accuracy = 98.5f,
                PlayCount = 200,
                CountRankA = 10,
                CountRankS = 5,
                CountRankSH = 5,
                CountRankSS = 5,
                CountRankSSH = 5,
                Level = 100,
                PPCountryRank = 5,
                PPRank = 5,
                PPRaw = 5000,
                TotalSecondsPlayed = 3600,
                Events = new[] {
                    new EventInfo {
                        DisplayHtml = "Test Event",
                        BeatmapId = 1,
                        BeatmapSetId = 1,
                        DateTime = new DateTime(2023, 1, 1),
                        EpicFactor = 1
                    }
                }
            };

            // Act
            var json = JsonConvert.SerializeObject(user);
            var deserializedUser = JsonConvert.DeserializeObject<User>(json);

            // Assert
            Assert.NotNull(deserializedUser);
            Assert.Equal(user.UserId, deserializedUser.UserId);
            Assert.Equal(user.Username, deserializedUser.Username);
            Assert.Equal(user.Country, deserializedUser.Country);
            Assert.Equal(user.JoinDate, deserializedUser.JoinDate);
            Assert.Equal(user.Count300, deserializedUser.Count300);
            Assert.Equal(user.Count100, deserializedUser.Count100);
            Assert.Equal(user.Count50, deserializedUser.Count50);
            Assert.Equal(user.RankedScore, deserializedUser.RankedScore);
            Assert.Equal(user.TotalScore, deserializedUser.TotalScore);
            Assert.Equal(user.Accuracy, deserializedUser.Accuracy);
            Assert.Equal(user.PlayCount, deserializedUser.PlayCount);
            Assert.Equal(user.CountRankA, deserializedUser.CountRankA);
            Assert.Equal(user.CountRankS, deserializedUser.CountRankS);
            Assert.Equal(user.CountRankSH, deserializedUser.CountRankSH);
            Assert.Equal(user.CountRankSS, deserializedUser.CountRankSS);
            Assert.Equal(user.CountRankSSH, deserializedUser.CountRankSSH);
            Assert.Equal(user.Level, deserializedUser.Level);
            Assert.Equal(user.PPCountryRank, deserializedUser.PPCountryRank);
            Assert.Equal(user.PPRank, deserializedUser.PPRank);
            Assert.Equal(user.PPRaw, deserializedUser.PPRaw);
            Assert.Equal(user.TotalSecondsPlayed, deserializedUser.TotalSecondsPlayed);
            Assert.NotNull(deserializedUser.Events);
            Assert.Single(deserializedUser.Events);
            Assert.Equal(user.Events[0].DisplayHtml, deserializedUser.Events[0].DisplayHtml);
            Assert.Equal(user.Events[0].BeatmapId, deserializedUser.Events[0].BeatmapId);
            Assert.Equal(user.Events[0].BeatmapSetId, deserializedUser.Events[0].BeatmapSetId);
            Assert.Equal(user.Events[0].DateTime, deserializedUser.Events[0].DateTime);
            Assert.Equal(user.Events[0].EpicFactor, deserializedUser.Events[0].EpicFactor);
            Assert.Equal(user.GetAvatar(), deserializedUser.GetAvatar());
            Assert.Equal(user.GetUrl(), deserializedUser.GetUrl());
            Assert.Equal($"https://s.ppy.sh/a/{user.UserId}", deserializedUser.GetAvatar());
            Assert.Equal($"https://osu.ppy.sh/users/{user.UserId}", deserializedUser.GetUrl());
        }
    }
}

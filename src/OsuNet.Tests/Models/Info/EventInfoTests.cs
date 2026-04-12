using Newtonsoft.Json;
using OsuNet.Models.Info;

namespace OsuNet.Tests.Models.Info
{
    public class EventInfoTests
    {
        [Fact]
        public void EventInfo_ShouldSerializeAndDeserializeCorrectly()
        {
            // Arrange
            var eventInfo = new EventInfo
            {
                DisplayHtml = "Event",
                BeatmapId = 123,
                BeatmapSetId = 456,
                DateTime = new DateTime(2023, 1, 1),
                EpicFactor = 10
            };

            // Act
            var json = JsonConvert.SerializeObject(eventInfo);
            var deserializedEventInfo = JsonConvert.DeserializeObject<EventInfo>(json);

            // Assert
            Assert.NotNull(deserializedEventInfo);
            Assert.Equal(eventInfo.DisplayHtml, deserializedEventInfo.DisplayHtml);
            Assert.Equal(eventInfo.BeatmapId, deserializedEventInfo.BeatmapId);
            Assert.Equal(eventInfo.BeatmapSetId, deserializedEventInfo.BeatmapSetId);
            Assert.Equal(eventInfo.DateTime, deserializedEventInfo.DateTime);
            Assert.Equal(eventInfo.EpicFactor, deserializedEventInfo.EpicFactor);
        }
    }
}
using OsuNet.Enums;

namespace OsuNet.Models.Options {
    public class GetScoresOptions {
        private ulong? beatmapId;

        /// <summary>
        /// BeatmapId is a required option.<br/>NOT BeatmapSetId
        /// </summary>
        public ulong? BeatmapId {
            get => beatmapId;
            set {
                if (value == null || value <= 0) {
                    throw new ArgumentException("BeatmapId must be a positive number.");
                }
                beatmapId = value;
            }
        }

        public string User { get; set; }
        public BeatmapMode? Mode { get; set; } = 0;
        public Mods? Mods { get; set; }
        public string Type { get; set; }
        public int? Limit { get; set; } = 50;
    }
}

using OsuNet.Enums;

namespace OsuNet.Models.Options {
    public class GetReplayOptions {
        private ulong beatmapId;
        private string user;

        /// <summary>
        /// BeatmapId is a required option.<br/>NOT BeatmapSetId.
        /// </summary>
        public ulong BeatmapId {
            get => beatmapId;
            set {
                if (value <= 0) {
                    throw new ArgumentException("BeatmapId must be a positive number.");
                }
                beatmapId = value;
            }
        }

        /// <summary>
        /// User is a required option.
        /// </summary>
        public string User {
            get => user;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("User cannot be null or empty.");
                }
                user = value;
            }
        }

        public BeatmapMode? Mode { get; set; }
        public string ScoreId { get; set; }
        public string Type { get; set; }
        public Mods? Mods { get; set; }
    }
}

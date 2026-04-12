using OsuNet.Enums;

namespace OsuNet.Models.Options {
    public class GetUserOptions {
        private string user;

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

        public BeatmapMode? Mode { get; set; } = 0;
        public string Type { get; set; }
        public byte? EventDays { get; set; } = 1;
    }
}

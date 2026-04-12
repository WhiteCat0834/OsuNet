namespace OsuNet.Models.Options {
    public class GetMatchOptions {
        private ulong? matchId;

        /// <summary>
        /// MatchId is a required option.
        /// </summary>
        public ulong? MatchId {
            get => matchId;
            set {
                if (value == null || value <= 0) {
                    throw new ArgumentException("MatchId must be a positive number.");
                }
                matchId = value;
            }
        }
    }
}

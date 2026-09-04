using System.Collections.Generic;

namespace OsuNet.Replays.Models {
    /// <summary>
    /// Represents the parsed data of an osu! replay file, containing the random seed and the sequence of player inputs.
    /// </summary>
    public class ReplayData {
        /// <summary>
        /// Gets or sets the random seed (RNG seed) used by the game client during the playback of this replay.
        /// </summary>
        public int Seed { get; set; }

        /// <summary>
        /// Gets or sets the chronological collection of replay frames containing the player's cursor movements and key presses over time.
        /// </summary>
        public List<ReplayFrame> ReplayFrames { get; set; } = new List<ReplayFrame>();
    }
}

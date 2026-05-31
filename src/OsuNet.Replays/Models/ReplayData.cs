using System;
using System.Collections.Generic;
using System.Text;

namespace OsuNet.Replays.Models {
    public class ReplayData {
        public int Seed { get; set; }
        public List<ReplayFrame> ReplayFrames { get; set; } = new List<ReplayFrame>();
    }
}

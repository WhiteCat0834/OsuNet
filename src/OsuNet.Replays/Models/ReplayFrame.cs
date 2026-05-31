namespace OsuNet.Replays.Models {
    public class ReplayFrame {
        public int TimeDiff { get; set; }
        public int Time { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int RawKeys { get; set; }
    }
}

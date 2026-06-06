using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    public class ReplayFrame {
        public int TimeDiff { get; set; }
        public int Time { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int RawKeys { get; set; }
        public OsuKeys OsuKeys => (OsuKeys)RawKeys;
        public TaikoKeys TaikoKeys => (TaikoKeys)RawKeys;
        public ManiaKeys ManiaKeys => (ManiaKeys)RawKeys;
        public CatchKeys CatchKeys => (CatchKeys)RawKeys;
    }
}

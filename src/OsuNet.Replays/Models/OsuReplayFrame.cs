using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    public class OsuReplayFrame : ReplayFrame {
        public OsuKeys OsuKeys => (OsuKeys)RawKeys;
    }
}

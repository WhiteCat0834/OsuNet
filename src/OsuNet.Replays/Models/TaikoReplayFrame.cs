using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    public class TaikoReplayFrame : ReplayFrame {
        public TaikoKeys TaikoKeys => (TaikoKeys)RawKeys;
    }
}

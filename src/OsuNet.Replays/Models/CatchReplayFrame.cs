using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    public class CatchReplayFrame : ReplayFrame {
        public CatchKeys CatchKeys => (CatchKeys)RawKeys;
    }
}

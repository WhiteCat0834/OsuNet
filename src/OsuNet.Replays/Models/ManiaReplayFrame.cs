using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    public class ManiaReplayFrame : ReplayFrame {
        public ManiaKeys ManiaKeys => (ManiaKeys)RawKeys;
    }
}

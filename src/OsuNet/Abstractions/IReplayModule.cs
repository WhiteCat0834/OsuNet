using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IReplayModule {
        Task<Replay> GetReplayAsync(GetReplayOptions options, CancellationToken cancellationToken = default);
    }
}

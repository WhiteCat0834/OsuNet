using OsuNet.Models.Options;

namespace OsuNet.Replays.Abstractions {
    public interface IOsuOsrService {
        Task<byte[]> GetOsrByteAsync(GetReplayOptions options, CancellationToken ct = default);
    }
}

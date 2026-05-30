using OsuNet.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuNet.Replays.Abstractions {
    public interface IOsuOsrService {
        Task<Stream> GetOsrStreamAsync(GetReplayOptions options, CancellationToken ct = default);
        Task<byte[]> GetOsrByteAsync(GetReplayOptions options, CancellationToken ct = default);
    }
}

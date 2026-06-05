using OsuNet.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OsuNet.Replays.Abstractions {
    public interface IOsuOsrService {
        Task<byte[]> GetOsrByteAsync(GetReplayOptions options, CancellationToken ct = default);
    }
}

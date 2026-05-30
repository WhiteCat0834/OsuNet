using OsuNet.Abstractions;
using OsuNet.Models.Options;
using OsuNet.Replays.Abstractions;
using OsuNet.Replays.Extensions;

namespace OsuNet.Replays.Services {
    public class OsuOsrService : IOsuOsrService {
        private readonly IOsuApi api;

        public OsuOsrService(IOsuApi api) { 
            this.api = api; 
        }
        /// <summary>
        /// Gets replay as .osr stream.
        /// </summary>
        public async Task<Stream> GetOsrStreamAsync(GetReplayOptions options, CancellationToken ct = default)
            => await api.GetOsrMemoryStreamAsync(options, ct);

        /// <summary>
        /// Gets replay as .osr byte array.
        /// </summary>
        public async Task<byte[]> GetOsrByteAsync(GetReplayOptions options, CancellationToken ct = default)
            => (await api.GetOsrMemoryStreamAsync(options, ct)).ToArray();
    }
}

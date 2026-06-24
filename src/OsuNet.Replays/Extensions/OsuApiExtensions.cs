using OsuNet.Abstractions;
using OsuNet.Models.Options;
using OsuNet.Replays.Abstractions;
using OsuNet.Replays.Services;

namespace OsuNet.Replays.Extensions {
    /// <summary>
    /// Extension methods for generating .osr replay files from OsuAPI data.
    /// </summary>
    public static class OsuApiExtensions {
        /// <summary>
        /// Create Osu Osr Service.
        /// </summary>
        /// <param name="api">Interface <see cref="IOsuApi" /></param>
        /// <returns><see cref="IOsuOsrService"/>.</returns>
        public static IOsuOsrService CreateOsuOsrService(this IOsuApi api)
             => new OsuOsrService(api);

        /// <summary>
        /// Gets replay as .osr byte array.
        /// </summary>
        public static async Task<byte[]> GetOsrByteAsync(this IOsuApi api, GetReplayOptions options, CancellationToken ct = default)
            => await api.CreateOsuOsrService().GetOsrByteAsync(options, ct);
    }
}

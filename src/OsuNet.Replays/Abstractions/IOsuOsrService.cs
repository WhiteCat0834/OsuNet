using OsuNet.Models.Options;

namespace OsuNet.Replays.Abstractions {
    /// <summary>
    /// Represents a contract for a service that provides functionality for downloading raw osu! replay (.osr) file data.
    /// </summary>
    public interface IOsuOsrService {
        /// <summary>
        /// Asynchronously retrieves the raw byte content of an osu! replay (.osr) file for the specified options.
        /// </summary>
        /// <param name="options">Configuration options for specifying which replay to download.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the raw byte array of the requested .osr replay file.</returns>
        Task<byte[]> GetOsrByteAsync(GetReplayOptions options, CancellationToken ct = default);
    }
}
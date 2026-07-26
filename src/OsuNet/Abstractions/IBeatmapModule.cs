using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IBeatmapModule {
        Task<Beatmap[]> GetBeatmapsAsync(GetBeatmapsOptions options, CancellationToken cancellationToken = default);
    }
}

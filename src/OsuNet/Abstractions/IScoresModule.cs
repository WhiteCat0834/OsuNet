using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IScoresModule {
        Task<Score[]> GetScoresAsync(GetScoresOptions options, CancellationToken cancellationToken = default);
    }
}

using OsuNet.Models;
using OsuNet.Models.Options;

namespace OsuNet.Abstractions {
    public interface IMultiplayerModule {
        Task<Match> GetMatchAsync(GetMatchOptions options, CancellationToken cancellationToken = default);
    }
}

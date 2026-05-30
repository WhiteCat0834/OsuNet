using OsuNet.Abstractions;
using OsuNet.Models.Options;
using OsuNet.Replays.Utils;

namespace OsuNet.Replays.Extensions {
    /// <summary>
    /// Extension methods for generating .osr replay files from OsuAPI data.
    /// </summary>
    public static class OsuApiExtensions {
        /// <summary>
        /// Gets replay as .osr stream.
        /// </summary>
        public static async Task<Stream> GetOsrStreamAsync(this IOsuApi api, GetReplayOptions options, CancellationToken ct = default) 
            => await api.GetOsrMemoryStreamAsync(options, ct);

        /// <summary>
        /// Gets replay as .osr byte array.
        /// </summary>
        public static async Task<byte[]> GetOsrByteAsync(this IOsuApi api, GetReplayOptions options, CancellationToken ct = default)
            => (await api.GetOsrMemoryStreamAsync(options, ct)).ToArray();

        /// <summary>
        /// Internal method that builds the .osr MemoryStream.
        /// </summary>
        internal static async Task<MemoryStream> GetOsrMemoryStreamAsync(this IOsuApi api, GetReplayOptions options, CancellationToken ct = default) {
            var t1 = api.GetReplayAsync(options, ct);
            var t2 = api.GetScoresAsync(new GetScoresOptions() {
                BeatmapId = options.BeatmapId,
                User = options.User,
                Mods = options.Mods,
                Mode = options.Mode,
                Type = options.Type
            }, ct);
            var t3 = api.GetBeatmapsAsync(new GetBeatmapsOptions() {
                BeatmapId = options.BeatmapId,
                Type = options.Type,
                Mode = options.Mode
            }, ct);
            await Task.WhenAll(t1, t2, t3);

            var replay = await t1;
            var score = (await t2).First();
            var beatmap = (await t3).First();

            var ms = new MemoryStream();
            var bw = new SerializationWriter(ms);

            var content = Convert.FromBase64String(replay.Content);
            var replayHashData = CryptoHelper.ComputeMd5Hash(
                score.MaxCombo + "osu" + score.Username +
                beatmap.FileMD5 + score.TotalScore + score.Rank
            );

            bw.Write((byte)options.Mode!);
            bw.Write(0);                                      // OsuVersion (unable to get value via API)
            bw.Write(beatmap.FileMD5);
            bw.Write(score.Username);
            bw.Write(replayHashData);
            bw.Write(score.Count300);
            bw.Write(score.Count100);
            bw.Write(score.Count50);
            bw.Write(score.CountGeki);
            bw.Write(score.CountKatu);
            bw.Write(score.CountMiss);
            bw.Write(score.TotalScore);
            bw.Write(score.MaxCombo);
            bw.Write((byte)(score.IsPerfect ? 1 : 0));
            bw.Write((int)score.EnabledMods);
            bw.Write("");                                     // lifebar (unable to get value via API)
            bw.Write(score.DateTime);
            bw.Write(content.Length);
            bw.Write(content);
            bw.Write(score.ScoreId);

            ms.Position = 0;
            return ms;
        }
    }
}

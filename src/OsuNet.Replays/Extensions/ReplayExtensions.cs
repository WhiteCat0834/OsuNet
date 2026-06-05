using OsuNet.Models;
using OsuNet.Replays.Models;
using SevenZip;
using System.Globalization;
using System.Text;

namespace OsuNet.Replays.Extensions {
    /// <summary>
    /// Extension methods for replay.
    /// </summary>
    public static class ReplayExtensions {
        private const string seedMarker = "-12345";

        /// <summary>
        /// Decode replay data.
        /// </summary>
        /// <param name="replay">Class <see cref="Replay" /></param>
        /// <param name="ct">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns></returns>
        public static async Task<ReplayData> DecodeAsync(this Replay replay, CancellationToken ct = default) {
            return await Task.Run(() => Decode(replay), ct);
        }

        private static ReplayData Decode(Replay replay) {
            var content = Convert.FromBase64String(replay.Content);

            using var stream = new MemoryStream(content, false);

            var replayData = new ReplayData();

            if (content.Length > 0) {
                byte[] decompressedBytes = LZMAHelper.Decompress(stream).ToArray();
                string decompressedString = Encoding.ASCII.GetString(decompressedBytes);
                int lastTime = 0;

                foreach (string frame in decompressedString.Split(',')) {
                    if (string.IsNullOrEmpty(frame))
                        continue;

                    string[] split = frame.Split('|');

                    if (split.Length < 4)
                        continue;

                    if (split[0] == seedMarker) {
                        replayData.Seed = Convert.ToInt32(split[3]);
                        continue;
                    }

                    int timeDiff = int.Parse(split[0], NumberStyles.Integer, CultureInfo.InvariantCulture);
                    float x = float.Parse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture);
                    float y = float.Parse(split[2], NumberStyles.Float, CultureInfo.InvariantCulture);
                    int rawKeys = Convert.ToInt32(split[3]);

                    var replayFrame = new ReplayFrame {
                        TimeDiff = timeDiff,
                        Time = lastTime + timeDiff,
                        X = x,
                        Y = y,
                        RawKeys = rawKeys
                    };

                    replayData.ReplayFrames.Add(replayFrame);
                    lastTime += timeDiff;
                }
            }
            return replayData;
        }
    }
}

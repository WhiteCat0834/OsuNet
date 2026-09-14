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

        /// <summary>
        /// Decodes and parses the compressed base64 replay content into an immutable <see cref="ReplayData"/> object.
        /// </summary>
        /// <param name="replay">The replay object containing the base64 encoded and LZMA compressed replay data.</param>
        /// <returns>
        /// A fully parsed <see cref="ReplayData"/> instance containing the RNG seed and a list of replay frames. 
        /// Returns an empty <see cref="ReplayData"/> if the content is empty.
        /// </returns>
        /// <remarks>
        /// This method utilizes <see cref="ReadOnlySpan{Char}"/> for zero-allocation string parsing, 
        /// significantly reducing Garbage Collector pressure compared to traditional <c>string.Split</c>.
        /// </remarks>
        private static ReplayData Decode(Replay replay) {
            if (string.IsNullOrEmpty(replay.Content)) {
                return new ReplayData(0, Array.Empty<ReplayFrame>());
            }

            var content = Convert.FromBase64String(replay.Content);
            if (content.Length == 0) {
                return new ReplayData(0, Array.Empty<ReplayFrame>());
            }

            using var stream = new MemoryStream(content, false);
            byte[] decompressedBytes = LZMAHelper.Decompress(stream).ToArray();
            string decompressedString = Encoding.ASCII.GetString(decompressedBytes);

            ReadOnlySpan<char> span = decompressedString.AsSpan();

            int seed = 0;
            var frames = new List<ReplayFrame>();
            int lastTime = 0;

            ReadOnlySpan<char> seedMarkerSpan = seedMarker.AsSpan();

            while (span.Length > 0) {
                int commaIndex = span.IndexOf(',');
                ReadOnlySpan<char> frameSpan = commaIndex >= 0 ? span.Slice(0, commaIndex) : span;
                span = commaIndex >= 0 ? span.Slice(commaIndex + 1) : ReadOnlySpan<char>.Empty;

                if (frameSpan.IsEmpty) continue;

                int pipe1 = frameSpan.IndexOf('|');
                if (pipe1 < 0) continue;

                ReadOnlySpan<char> part0 = frameSpan.Slice(0, pipe1);
                frameSpan = frameSpan.Slice(pipe1 + 1);

                int pipe2 = frameSpan.IndexOf('|');
                if (pipe2 < 0) continue;

                ReadOnlySpan<char> part1 = frameSpan.Slice(0, pipe2);
                frameSpan = frameSpan.Slice(pipe2 + 1);

                int pipe3 = frameSpan.IndexOf('|');
                if (pipe3 < 0) continue;

                ReadOnlySpan<char> part2 = frameSpan.Slice(0, pipe3);
                ReadOnlySpan<char> part3 = frameSpan.Slice(pipe3 + 1);

                if (part0.SequenceEqual(seedMarkerSpan)) {
                    seed = int.Parse(part3, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    continue;
                }

                int timeDiff = int.Parse(part0, NumberStyles.Integer, CultureInfo.InvariantCulture);
                float x = float.Parse(part1, NumberStyles.Float, CultureInfo.InvariantCulture);
                float y = float.Parse(part2, NumberStyles.Float, CultureInfo.InvariantCulture);
                int rawKeys = int.Parse(part3, NumberStyles.Integer, CultureInfo.InvariantCulture);

                frames.Add(new ReplayFrame(
                    TimeDiff: timeDiff,
                    Time: lastTime + timeDiff,
                    X: x,
                    Y: y,
                    RawKeys: rawKeys
                ));
                lastTime += timeDiff;
            }

            return new ReplayData(seed, frames);
        }
    }
}

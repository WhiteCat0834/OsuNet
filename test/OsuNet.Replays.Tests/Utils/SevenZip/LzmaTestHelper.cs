using System;
using System.Collections.Generic;
using System.Text;

namespace SevenZip {
    /// <summary>
    /// Helper to compress strings into the specific LZMA format expected by OsuNet.Replays.Utils.LZMAHelper.
    /// Format: [5 bytes properties] [8 bytes uncompressed size (LE)] [compressed data]
    /// </summary>
    internal static class LzmaTestHelper {
        public static string CompressToBase64(string input) {
            var encoder = new Compression.LZMA.Encoder();
            using var inStream = new MemoryStream(Encoding.ASCII.GetBytes(input));
            using var outStream = new MemoryStream();

            // 1. Write LZMA properties (5 bytes)
            encoder.WriteCoderProperties(outStream);

            // 2. Write uncompressed size (8 bytes, little-endian)
            long uncompressedSize = inStream.Length;
            for (int i = 0; i < 8; i++) {
                outStream.WriteByte((byte)(uncompressedSize >> (8 * i)));
            }

            // 3. Compress the actual data
            inStream.Position = 0;
            encoder.Code(inStream, outStream, -1, -1, null);

            outStream.Flush();
            return Convert.ToBase64String(outStream.ToArray());
        }
    }
}

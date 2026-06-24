using SevenZip.Compression.LZMA;

namespace SevenZip {
    internal class LZMAHelper {
        public static MemoryStream Decompress(Stream inStream) {
            var decoder = new Decoder();

            byte[] properties = new byte[5];
            if (inStream.Read(properties, 0, 5) != 5)
                throw new Exception("input .lzma is too short");
            decoder.SetDecoderProperties(properties);

            long outSize = 0;
            for (int i = 0; i < 8; i++) {
                int v = inStream.ReadByte();
                if (v < 0)
                    break;
                outSize |= ((long)(byte)v) << (8 * i);
            }
            long compressedSize = inStream.Length - inStream.Position;

            var outStream = new MemoryStream();
            decoder.Code(inStream, outStream, compressedSize, outSize);
            outStream.Flush();
            outStream.Position = 0;
            return outStream;
        }
    }
}
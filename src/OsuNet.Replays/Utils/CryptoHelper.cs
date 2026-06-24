using System.Text;

namespace OsuNet.Replays.Utils {
    internal class CryptoHelper {
        internal static string ComputeMd5Hash(string input) {
            if (input is null) throw new ArgumentNullException(nameof(input));

            using var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder(32);
            for (int i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

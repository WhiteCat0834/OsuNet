using System.Text;

namespace OsuNet.Replays.Utils {
    /// <summary>
    /// Provides helper methods for cryptographic operations.
    /// </summary>
    internal class CryptoHelper {
        /// <summary>
        /// Computes the MD5 hash of the specified string input using UTF-8 encoding.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>A 32-character lowercase hexadecimal string representing the MD5 hash.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is <c>null</c>.</exception>
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
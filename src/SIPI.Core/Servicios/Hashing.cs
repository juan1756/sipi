using System.Security.Cryptography;
using System.Text;

namespace SIPI.Core.Servicios
{
    public class Hashing
    {
        public static HashAlgorithm Algorithm { private get; set; }

        static Hashing()
        {
            Algorithm = new SHA1Managed();
        }

        public static byte[] Hash(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            return Algorithm.ComputeHash(bytes);
        }

        public static string HexStringFromHashBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static string HashToString(string s)
        {
            return HexStringFromHashBytes(Hash(s));
        }
    }
}
using System.Security.Cryptography;
using System.Text;

namespace UrlShortner.Utilites
{
    public class HashHElper
    {
        public static string CreateHashHelper(string input)
        {
            return Generatesha512(input)[..8];
        }

        private static string Generatesha512(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashInputByte = hash.ComputeHash(bytes);
            var hashInputStringBuilder=new StringBuilder(128);
            foreach (var item in hashInputByte)
            {
                hashInputStringBuilder.Append(item.ToString("x2"));
            }

            return hashInputStringBuilder.ToString();
        }
    }
}

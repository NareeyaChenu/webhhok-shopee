
using System.Security.Cryptography;
using System.Text;

namespace ShopeeLib.Services
{
    public static class SignatureHelper
    {
        public static string GenerateSignKey(string data, string secret)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
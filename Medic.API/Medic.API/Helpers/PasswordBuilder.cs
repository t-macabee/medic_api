using System.Security.Cryptography;
using System.Text;

namespace Medic.API.Helpers
{
    public static class PasswordBuilder
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);

            using var hmac = new HMACSHA256(saltBytes);
            byte[] hashBytes = hmac.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string salt, string password, string storedHash)
        {
            string hash = GenerateHash(salt, password);
            return hash == storedHash;
        }
    }
}

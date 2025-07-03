using BaseLibrary.Application.Interfaces.Utils;
using System.Security.Cryptography;

namespace BaseLibrary.Infrastructure.Services.Utils.Hashing
{
    public class Pbkdf2HashingService : IHashingService
    {
        public int Iterations { get; set; } = 100000;
        public int SaltSize { get; set; } = 32; // 256 bits
        public int HashSize { get; set; } = 32; // 256 bits

        public string Hash(string input, byte[] salt = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            }
            if (salt == null)
            {
                salt = GenerateRandomSalt();
            }
            byte[] hash = HashWithSalt(input, salt, Iterations);
            string hashString = Convert.ToBase64String(hash);
            string hashSaltString = Convert.ToBase64String(salt);
            return $"{Iterations}${hashString}${hashSaltString}";
        }
        public bool CompareHash(string hash, string storedHash)
        {
            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }
            try
            {
                string[] parts = storedHash.Split('$');
                if (parts.Length != 3)
                {
                    return false; // Invalid hash format
                }
                int iterations = int.Parse(parts[0]);
                byte[] storedHashBytes = Convert.FromBase64String(parts[1]);
                byte[] storedSalt = Convert.FromBase64String(parts[2]);

                byte[] computedHash = HashWithSalt(hash, storedSalt, iterations);
                return ConstantTimeEquals(computedHash, storedHashBytes);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        private byte[] HashWithSalt(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }
        private static bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }
    }
}

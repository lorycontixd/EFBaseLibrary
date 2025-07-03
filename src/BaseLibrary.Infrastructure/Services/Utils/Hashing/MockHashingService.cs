using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Infrastructure.Services.Utils.Hashing
{
    /// <summary>
    /// Service for mocking hashing operations.
    /// This implementation is to be used only in testing scenarios.
    /// </summary>
    public class MockHashingService
    {
        public Dictionary<string, string> StoredHashes { get; } = new();

        public string Hash(string input, byte[] salt = null)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            // Simple mock implementation
            string hash = $"mock_hash_{input.GetHashCode()}";
            StoredHashes[input] = hash;
            return hash;
        }

        public bool CompareHash(string hash, string storedHash)
        {
            return StoredHashes.ContainsKey(hash) && StoredHashes[hash] == storedHash;
        }
    }
}

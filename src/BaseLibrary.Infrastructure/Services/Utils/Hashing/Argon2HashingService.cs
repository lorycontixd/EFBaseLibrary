using BaseLibrary.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Infrastructure.Services.Utils.Hashing
{
    /// <summary>
    /// Service for hashing using the Argon2 algorithm.
    /// This algorithm is designed to be memory-hard and resistant to GPU-based attacks, making it the most suitable for password hashing.
    /// </summary>
    public class Argon2HashingService : IHashingService
    {
        // Placeholder for Argon2 implementation
        // This class should implement the IHashingService interface using Argon2 hashing algorithm
        public string Hash(string input, byte[] salt = null)
        {
            throw new NotImplementedException("Argon2 hashing is not implemented yet.");
        }
        public bool CompareHash(string hash, string storedHash)
        {
            throw new NotImplementedException("Argon2 hash comparison is not implemented yet.");
        }

        // Additional properties and methods for Argon2 configuration can be added here
    }
}

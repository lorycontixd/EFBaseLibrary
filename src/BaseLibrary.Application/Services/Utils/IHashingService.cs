namespace BaseLibrary.Application.Services.Utils
{
    public interface IHashingService
    {
        public string Hash(string input, byte[] salt = null);
        public bool CompareHash(string hash, string storedHasht);
    }
}
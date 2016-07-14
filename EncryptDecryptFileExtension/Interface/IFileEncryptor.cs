namespace EncryptDecryptFileExtension.Interface
{
    public interface IFileEncryptor
    {
        void Encrypt(string inputFile, string outputFile, string username, string password);
    }
}
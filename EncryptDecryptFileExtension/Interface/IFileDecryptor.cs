namespace EncryptDecryptFileExtension.Interface
{
    public interface IFileDecryptor
    {
        void Decrypt(string inputFile, string outputFile, string username, string password);
    }
}
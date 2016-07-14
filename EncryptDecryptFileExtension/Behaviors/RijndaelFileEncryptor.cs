using System.IO;
using System.Security.Cryptography;
using EncryptDecryptFileExtension.Interface;

namespace EncryptDecryptFileExtension.Behaviors
{
    public class RijndaelFileEncryptor : IFileEncryptor
    {
        public void Encrypt(string inputFile, string outputFile, string username, string password)
        {
            Guard.NotNullOrEmpty(() => inputFile, inputFile);
            Guard.NotNullOrEmpty(() => outputFile, outputFile);
            Guard.NotNullOrEmpty(() => username, username);
            Guard.NotNullOrEmpty(() => password, password);

            byte[] key = HashKeyCreator.CreateKey(username, password);

            using (RijndaelManaged managedRijndael = new RijndaelManaged())
            {
                managedRijndael.Key = key;
                managedRijndael.IV = System.Text.Encoding.ASCII.GetBytes(password);
                
                var encryptor = managedRijndael.CreateEncryptor();
                
                // Create the streams used for encryption.
                using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                    {
                        // By encrypting a chunk at
                        // a time, you can save memory
                        // and accommodate large files.
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes can be any arbitrary size.
                        int blockSizeBytes = managedRijndael.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open))
                        {
                            do
                            {
                                count = inputFileStream.Read(data, 0, blockSizeBytes);
                                offset += count;
                                csEncrypt.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            }
                            while (count > 0);
                            inputFileStream.Close();
                        }

                        csEncrypt.FlushFinalBlock();
                        csEncrypt.Close();
                    }
                }
            }
        }
    }
}
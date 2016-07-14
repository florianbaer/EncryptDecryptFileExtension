using System;
using EncryptDecryptFileExtension.Behaviors;
using EncryptDecryptFileExtension.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncryptDecryptFileExtension.Tests
{
    [TestClass]
    public class EncryptFileTests
    {
        [TestMethod]
        [DeploymentItem("Resources")]
        public void SuccessfulEncryptFileTest()
        {
            IFileEncryptor encryptor = new RijndaelFileEncryptor();
            encryptor.Encrypt($"{Environment.CurrentDirectory}/Testfile.txt", $"{Environment.CurrentDirectory}/Testfile.enc", "user", "pw");

            IFileEncryptor decryptor = new RijndaelFileDecryptor();
            decryptor.Encrypt($"{Environment.CurrentDirectory}/Testfile.enc", $"{Environment.CurrentDirectory}/Testfile.ttxt", "user", "pw");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptFileExtension.Behaviors
{
    internal static class HashKeyCreator
    {
        public static byte[] CreateKey(string username, string password)
        {
            MD5 md5 = MD5.Create();

            byte[] keypassword = Encoding.ASCII.GetBytes(username);
            return md5.ComputeHash(keypassword);
        }
    }
}

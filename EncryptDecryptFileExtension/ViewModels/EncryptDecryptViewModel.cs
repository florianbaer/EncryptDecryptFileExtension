using System;
using System.Collections.ObjectModel;
using EncryptDecryptFileExtension.Behaviors;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EncryptDecryptFileExtension.ViewModels
{
    public class EncryptDecryptViewModel : ViewModelBase
    {
        public EncryptDecryptViewModel(string file, Functionality functionality)
        {
            this.File = file;
            this.Function = functionality;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public Functionality Function { get; set; }

        public string FunctionName
        {
            get
            {
                return this.Function.ToString(); 
            }
        }

        public string File{get; }

        public RelayCommand EncryptDecryptFile
        {
            get
            {
                return new RelayCommand(EncryptDecrypt);
            }
        }

        private void EncryptDecrypt()
        {
            if (Function == Functionality.Decrypt)
            {
                new RijndaelFileDecryptor().Decrypt(this.File, this.File.Split(new string[] {".enc"}, StringSplitOptions.None)[0], this.Username, this.Password);
            }
            else if (Function == Functionality.Encrypt)
            {
                new RijndaelFileEncryptor().Encrypt(this.File, $"{this.File}.enc", this.Username, this.Password);
            }
        }


        public enum Functionality
        {
            Decrypt = 0,
            Encrypt = 1
        }
    }
}
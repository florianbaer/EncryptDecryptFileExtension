using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EncryptDecryptFileExtension.ViewModels
{
    public class EncyptViewModel : ViewModelBase
    {
        public EncyptViewModel(string[] files)
        {
            Files = files;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string[] Files{get; }

        public RelayCommand EncryptFiles
        {
            get
            {
                return new RelayCommand(EncryptFile);
            }
        }

        private void EncryptFile()
        {
            
        }
    }
}
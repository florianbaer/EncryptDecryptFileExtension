using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using EncryptDecryptFileExtension.Views;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace EncryptDecryptFileExtension
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]
    public class EncryptFileExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var strip = new ContextMenuStrip();

            var item = new ToolStripMenuItem()
            {
                Text = "Encrypt file"
            };

            item.Click += EncryptFile;
            strip.Items.Add(item);

            return strip;
        }

        private void EncryptFile(object sender, EventArgs eventArgs)
        {
            Window window = new Window
            {
                Title = $"Encrypt file {SelectedItemPaths.First()}",
                Content = new EncryptView()
            };

            window.ShowDialog();
        }
    }
}

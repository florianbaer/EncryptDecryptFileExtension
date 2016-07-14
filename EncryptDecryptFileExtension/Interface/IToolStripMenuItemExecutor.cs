namespace EncryptDecryptFileExtension.Interface
{
    public interface IToolStripMenuItemExecutor
    {
        void Execute(string file);

        void Execute(string[] files);
    }
}
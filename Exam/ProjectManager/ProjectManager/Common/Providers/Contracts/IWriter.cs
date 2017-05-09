namespace ProjectManager.Common.Providers.Contracts
{
    public interface IWriter
    {
        void Write();

        void Write(string text);

        void Write(char symbol);

        void WriteLine();

        void WriteLine(string text);
    }
}

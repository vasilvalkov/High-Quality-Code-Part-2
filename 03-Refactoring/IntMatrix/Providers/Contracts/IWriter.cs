namespace IntMatrix.Providers.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine();

        void WriteLine(string text);
    }
}

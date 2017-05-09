using ProjectManager.Common.Providers.Contracts;
using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write()
        {
            Console.WriteLine();
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(char symbol)
        {
            Console.WriteLine(symbol);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}

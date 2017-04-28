using IntMatrix.Providers.Contracts;
using System;

namespace IntMatrix.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
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

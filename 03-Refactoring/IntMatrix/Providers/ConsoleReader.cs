using System;
using IntMatrix.Providers.Contracts;

namespace IntMatrix.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string readInput = Console.ReadLine();

            return readInput;
        }
    }
}

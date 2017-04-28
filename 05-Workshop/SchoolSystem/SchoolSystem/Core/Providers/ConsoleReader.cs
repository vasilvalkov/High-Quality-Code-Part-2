using SchoolSystem.Core.Providers.Contracts;
using System;

namespace SchoolSystem.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

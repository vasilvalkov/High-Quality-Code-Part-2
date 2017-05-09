using ProjectManager.Common.Providers.Contracts;
using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

using SchoolSystem.Core;
using SchoolSystem.Core.Providers;

namespace SchoolSystem
{
    class Startup
    {
        static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var engine = new Engine(reader, writer);

            engine.Ignite();
        }
    }
}
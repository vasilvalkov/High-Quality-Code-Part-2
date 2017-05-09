using ProjectManager.Common;
using ProjectManager.Common.Providers;
using ProjectManager.Common.Providers.Contracts;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFileLogger fileLogger = new FileLogger();
            IDatabase db = new Database();
            IModelsFactory modelsFactory = new ModelsFactory();
            ICommandsFactory commandsFactory = new CommandsFactory(db, modelsFactory);
            ICommandProcessor commandProcessor = new CommandProcessor(commandsFactory);

            var engine = new Engine(fileLogger, commandProcessor, reader, writer);

            engine.Start();
        }
    }
}

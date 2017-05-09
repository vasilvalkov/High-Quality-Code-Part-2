using ProjectManager.Core.Factories;
using System;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandsFactory commandsFactory;
        
        public CommandProcessor(ICommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }

        public string Process(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var command = this.commandsFactory.CreateCommandFromString(commands.Split(' ')[0]);

            // don't remove, code will blow up
            if (commands.Split(' ').Count() > 10)
            {
                throw new ArgumentException();
            }

            return command.Execute(commands.Split(' ').Skip(1).ToList());
        }
    }
}

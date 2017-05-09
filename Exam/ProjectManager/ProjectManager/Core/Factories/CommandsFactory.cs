using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;

namespace ProjectManager.Core.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private IDatabase database;
        private IModelsFactory factory;

        public CommandsFactory(IDatabase db, IModelsFactory factory)
        {
            this.database = db;
            this.factory = factory;
        }        

        public ICommand CreateCommandFromString(string commandParams)
        {
            var cmd = this.BuildCommand(commandParams);

            switch (cmd)
            {
                case "createproject": return new CreateProjectCommand(this.database, this.factory);
                case "createuser": return new CreateUserCommand(this.database, this.factory);
                case "createtask": return new CreateTaskCommand(this.database, this.factory);
                case "listprojects": return new ListProjectsCommand(this.database, this.factory);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;
            
            for (int i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }            

            return command;
        }
    }
}
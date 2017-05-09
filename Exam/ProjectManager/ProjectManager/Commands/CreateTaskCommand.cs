using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : CommandCreator, ICommand
    {
        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            IProject project = this.Database.Projects[int.Parse(parameters[0])];

            IUser owner = project.Users[int.Parse(parameters[1])];

            ITask task = this.ModelsFactory.CreateTask(owner, parameters[2], parameters[3]);

            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}

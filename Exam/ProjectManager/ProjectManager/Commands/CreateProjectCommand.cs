using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : CommandCreator, ICommand
    {
        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
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

            if (this.Database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.ModelsFactory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);

            this.Database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}

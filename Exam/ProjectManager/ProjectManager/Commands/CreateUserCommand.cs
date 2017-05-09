using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : CommandCreator, ICommand
    {
        public CreateUserCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var modelsFactory = new ModelsFactory();

            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            IProject targetProject = this.Database.Projects[int.Parse(parameters[0])];

            if (targetProject.Users.Any() && targetProject.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            IUser user = modelsFactory.CreateUser(parameters[1], parameters[2]);

            targetProject.Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}

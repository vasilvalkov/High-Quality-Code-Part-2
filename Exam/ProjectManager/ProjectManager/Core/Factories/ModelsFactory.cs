using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Core.Factories;
using ProjectManager.Models.Contracts;
using System;

namespace ProjectManager.Models
{
    public class ModelsFactory : IModelsFactory
    {
        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            IProject project = new Project(name, starting, end, state);

            Validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            var task = new Task(name, owner, state);

            Validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);

            Validator.Validate(user);

            return user;
        }       
    }
}

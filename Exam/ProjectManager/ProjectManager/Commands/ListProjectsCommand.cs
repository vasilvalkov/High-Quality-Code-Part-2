using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using ProjectManager.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Commands
{
    public sealed class ListProjectsCommand : CommandCreator, ICommand
    {
        public ListProjectsCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {         
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var b = new StringBuilder();

            foreach (var project in this.Database.Projects)
            {
                b.AppendLine("Name: " + project.Name);
                b.AppendLine("  Starting date: " + project.StartingDate.ToString("yyyy-MM-dd"));
                b.AppendLine("  Ending date: " + project.EndingDate.ToString("yyyy-MM-dd"));
                b.AppendLine("  State: " + project.State);
                b.AppendLine("  Users: ");

                int usersCount = project.Users.Count;

                for (int count = 0; count < usersCount; count++)
                {                    
                    string userInfo = this.PrintUser(project.Users[count]);
                    b.Append(userInfo);

                    if (count == usersCount - 1)
                    {
                        break;
                    }

                    b.AppendLine("  -------------");
                }

                if (project.Users.Count == 0)
                {
                    b.AppendLine("  - This project has no users!");
                }

                b.AppendLine("  Tasks: ");

                int tasksCount = project.Tasks.Count;

                for (int count = 0; count < tasksCount; count++)
                {
                    string taskInfo = this.PrintTask(project.Tasks[count]);
                    b.AppendLine(taskInfo);

                    if (count == tasksCount - 1)
                    {
                        break;
                    }

                    b.AppendLine("  -------------");
                }

                if (project.Tasks.Count == 0)
                {
                    b.Append("  - This project has no tasks!");
                }
            }

            return b.ToString().Trim();
        }

        private string PrintUser(IUser user)
        {
            var b = new StringBuilder();
            b.AppendLine("    Username: " + user.Username);
            b.AppendLine("    Email: " + user.Email);
            return b.ToString();
        }

        private string PrintTask(ITask task)
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + task.Name);
            builder.AppendLine("    Owner: " + task.Owner.Username);
            builder.Append("    State: " + task.State);

            return builder.ToString();
        }
    }
}

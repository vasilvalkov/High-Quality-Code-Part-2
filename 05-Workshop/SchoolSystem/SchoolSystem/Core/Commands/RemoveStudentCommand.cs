using SchoolSystem.Core.Commands.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.Students.Remove(int.Parse(paras[0]));

            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}

using SchoolSystem.Core.Commands.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.teachers.Remove(int.Parse(paras[0]));

            return $"Teacher with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}

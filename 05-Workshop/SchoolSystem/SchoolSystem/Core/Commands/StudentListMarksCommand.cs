using SchoolSystem.Core.Commands.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}

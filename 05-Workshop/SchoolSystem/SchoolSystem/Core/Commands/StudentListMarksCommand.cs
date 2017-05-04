using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            try
            {
                int studentId = int.Parse(parameters[0]);
                IStudent student = Engine.Students[studentId];

                var allMarks = student.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

                return "The student has these marks:" +
                    Environment.NewLine +
                    string.Join("\n", allMarks) +
                    Environment.NewLine;
            }
            catch (KeyNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}

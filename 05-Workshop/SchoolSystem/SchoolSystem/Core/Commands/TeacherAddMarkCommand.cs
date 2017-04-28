using SchoolSystem.Core.Commands.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teecherId = int.Parse(prms[0]);
            var studentId = int.Parse(prms[1]);
            // Please work
            var students = Engine.students[teecherId];
            var teachers = Engine.teachers[studentId];

            teachers.AddMark(students, float.Parse(prms[2]));

            return $"Teacher {teachers.FirstName} {teachers.LastName} added mark {float.Parse(prms[2])} to student {students.FirstName} {students.LastName} in {teachers.Subject}.";
        }
    }
}

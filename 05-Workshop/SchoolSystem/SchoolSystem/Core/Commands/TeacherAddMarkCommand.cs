using SchoolSystem.Core.Commands.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teacherId = int.Parse(prms[0]);
            var studentId = int.Parse(prms[1]);
            var mark = float.Parse(prms[2]);
            // Please work
            var students = Engine.students[studentId];
            var teachers = Engine.teachers[teacherId];

            teachers.AddMark(students, mark);

            return $"Teacher {teachers.FirstName} {teachers.LastName} added mark {float.Parse(prms[2])} to student {students.FirstName} {students.LastName} in {teachers.Subject}.";
        }
    }
}

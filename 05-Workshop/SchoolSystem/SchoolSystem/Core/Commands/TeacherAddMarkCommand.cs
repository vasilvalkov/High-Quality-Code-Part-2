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
            var student = Engine.students[studentId];
            var teacher = Engine.teachers[teacherId];

            teacher.AddMark(student, mark);

            string outputMessege = $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
            
            return outputMessege;
        }
    }
}

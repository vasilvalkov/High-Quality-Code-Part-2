using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        public static int id = 0;

        public string Execute(IList<string> para)
        {
            Engine.Students.Add(id, new Student(para[0], para[1], (Grade)int.Parse(para[2])));

            return $"A new student with name {para[0]} {para[1]}, grade {(Grade)int.Parse(para[2])} and ID {id++} was created.";
        }
    }
}

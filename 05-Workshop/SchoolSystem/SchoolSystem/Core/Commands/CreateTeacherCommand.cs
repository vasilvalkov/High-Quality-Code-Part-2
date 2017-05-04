using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        public static int id = 0;

        public string Execute(IList<string> para)
        {
            Engine.Teachers.Add(id, new Teacher(para[0], para[1], (Subjct)int.Parse(para[2])));

            return $"A new teacher with name {para[0]} {para[1]}, subject {(Grade)int.Parse(para[2])} and ID {id++} was created.";
        }
    }
}

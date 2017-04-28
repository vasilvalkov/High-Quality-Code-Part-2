using SchoolSystem.Enums;
using SchoolSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {
        private const int MAX_MARKS_COUNT = 20;
        private Grade grade;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grade, IList<IMark> marks = null)
            : base(firstName, lastName)
        {            
            this.Grade = grade;
            this.Marks = marks;
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.grade = value;
            }
        }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                if (this.marks == null)
                {
                    this.marks = new List<IMark>();
                }
                else
                {
                    if (value.Count > 20)
                    {
                        throw new ArgumentException(string.Format("A student cannot have more than {0} marks!", MAX_MARKS_COUNT));
                    }

                    this.marks = value;
                }                
            }
        }

        public string ListMarks()
        {
            var allMarks = marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            return string.Join("\n", allMarks);
        }
    }
}

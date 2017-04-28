using SchoolSystem.Enums;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Teacher : Person, ITeacher
    {
        private Subjct subject;

        public Teacher(string firstName, string lastName, Subjct subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subjct Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        // If this comment is removed the program will blow up 
        public void AddMark(IStudent student, float mark)
        {
            var newMark = new Mark(this.Subject, mark);

            student.Marks.Add(newMark);
        }        
    }
}

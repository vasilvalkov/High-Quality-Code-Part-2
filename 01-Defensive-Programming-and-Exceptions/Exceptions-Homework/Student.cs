using System;
using System.Linq;
using System.Collections.Generic;

namespace Exceptions_Homework
{
    public class Student
    {
        private IList<Exam> exams;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("The first name cannot be null or empty!");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("The last name cannot be null or empty!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IList<Exam> Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                if (value == null)
                {
                    this.exams = new List<Exam>();
                }
                else
                {
                    this.exams = value;
                }
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams.Count == 0)
            {
                Console.WriteLine("The student has no exams!");
                return null;
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams.Count == 0)
            {
                return 0;
            }

            double[] examScore = new double[this.Exams.Count];

            IList<ExamResult> examResults = CheckExams();

            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}

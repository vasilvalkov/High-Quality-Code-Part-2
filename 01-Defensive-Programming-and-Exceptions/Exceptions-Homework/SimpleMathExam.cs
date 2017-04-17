using System;

namespace Exceptions_Homework
{
    public class SimpleMathExam : Exam
    {
        public int ProblemsSolved { get; private set; }

        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0 || 10 < problemsSolved)
            {
                throw new ArgumentException("Invalid number of problems solved! Shouold be between 0 and 10!");
            }

            this.ProblemsSolved = problemsSolved;
        }

        public override ExamResult Check()
        {
            if (ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (ProblemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            }
            else if (ProblemsSolved == 2)
            {
                return new ExamResult(6, 2, 6, "Average result: nothing done.");
            }

            throw new ArgumentException("Invalid number of problems solved!");
        }
    }
}
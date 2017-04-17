namespace Exceptions_Homework.UnitTests.Fakes
{
    public class FakeExamResult : ExamResult
    {
        public FakeExamResult(int grade, int minGrade, int maxGrade, string comments) 
            : base(grade, minGrade, maxGrade, comments)
        {
        }
    }
}

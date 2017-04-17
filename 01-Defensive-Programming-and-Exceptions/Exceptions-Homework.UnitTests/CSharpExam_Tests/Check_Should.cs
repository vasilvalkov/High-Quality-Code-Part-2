using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.CSharpExam_Tests
{
    [TestFixture]
    public class Check_Should
    {
        [Test]
        public void ReturnNewExamResult_WhenInvoked()
        {
            int validScore = 42;
            var exam = new CSharpExam(validScore);

            var result = exam.Check();

            Assert.AreEqual("ExamResult", result.GetType().Name);
        }
    }
}

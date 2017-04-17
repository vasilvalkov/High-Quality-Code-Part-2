using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.SimpleMathExam_Tests
{
    [TestFixture]
    public class Check_Should
    {
        [Test]
        public void ThrowArgumentException_WhenInvalidProblemsSolvedCount()
        {
            var exam = new SimpleMathExam(3);

            Assert.Throws<ArgumentException>(() => exam.Check());            
        }

        [Test]
        public void ReturnNewExamResultWithGrade2_WhenNoProblemsSolvedIsZero()
        {
            var exam = new SimpleMathExam(0);

            var result = exam.Check();

            Assert.AreEqual(2, result.Grade);
        }

        [Test]
        public void ReturnNewExamResultWithGrade4_WhenProblemsSolvedIsOne()
        {
            var exam = new SimpleMathExam(1);

            var result = exam.Check();

            Assert.AreEqual(4, result.Grade);
        }

        [Test]
        public void ReturnNewExamResultWithGrade6_WhenProblemsSolvedIsTwo()
        {
            var exam = new SimpleMathExam(2);

            var result = exam.Check();

            Assert.AreEqual(6, result.Grade);
        }        
    }
}

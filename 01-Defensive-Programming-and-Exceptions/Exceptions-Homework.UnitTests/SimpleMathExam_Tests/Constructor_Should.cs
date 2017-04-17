using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.SimpleMathExam_Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateNewSimpleMathExamObject_WhenThePassedParameterIsValid()
        {
            int validProblemsSolved = 5;

            var result = new SimpleMathExam(validProblemsSolved);

            Assert.AreEqual("SimpleMathExam", result.GetType().Name);
        }

        [Test]
        public void CorrectlyAssignProperty_WhenThePassedParameterIsValid()
        {
            int validProblemsSolved = 5;

            var result = new SimpleMathExam(validProblemsSolved);

            Assert.AreEqual(5, result.ProblemsSolved);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedParameterIsNegative()
        {
            int negativeProblemsSolved = -1;

            Assert.Throws<ArgumentException>(() => new SimpleMathExam(negativeProblemsSolved));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedParameterIsGreaterThan10()
        {
            int problemsSolved = 15;

            Assert.Throws<ArgumentException>(() => new SimpleMathExam(problemsSolved));
        }
    }
}

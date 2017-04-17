using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.CSharpExam_Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenThePassedScoreIsNegative()
        {
            int negativeScore = -1;

            Assert.Throws<ArgumentException>(() => new CSharpExam(negativeScore));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedScoreIsGreaterThan100()
        {
            int invalidScore = 101;

            Assert.Throws<ArgumentException>(() => new CSharpExam(invalidScore));
        }

        [Test]
        public void CreateNewCSharpExam_WhenThePassedScoreIsValid()
        {
            int validScore = 42;

            var result = new CSharpExam(validScore);

            Assert.AreEqual("CSharpExam", result.GetType().Name);
        }

        [Test]
        public void CorrectlyAssignScoreToProperty_WhenThePassedScoreIsValid()
        {
            int validScore = 42;

            var result = new CSharpExam(validScore);

            Assert.AreEqual(42, result.Score);
        }
    }
}

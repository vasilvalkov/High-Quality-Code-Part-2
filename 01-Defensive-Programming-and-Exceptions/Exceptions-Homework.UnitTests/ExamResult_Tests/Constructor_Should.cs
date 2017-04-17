using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.ExamResult_Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenThePassedGradeIsSmallerThanZero()
        {
            int invalidGrade = -1;
            int validMinGrade = 3;
            int validMaxGrade = 5;
            string validComments = "Some comments";

            Assert.Throws<ArgumentException>(
                () => new ExamResult(invalidGrade, validMinGrade, validMaxGrade, validComments));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedMinGradeIsSmallerThanZero()
        {
            int validGrade = 4;
            int validMinGrade = -1;
            int validMaxGrade = 5;
            string validComments = "Some comments";

            Assert.Throws<ArgumentException>(
                () => new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedMaxGradeIsSmallerThanThePassedMinGrade()
        {
            int validGrade = 4;
            int validMinGrade = 3;
            int validMaxGrade = 2;
            string validComments = "Some comments";

            Assert.Throws<ArgumentException>(
                () => new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedMaxGradeIsEqualToThePassedMinGrade()
        {
            int validGrade = 4;
            int validMinGrade = 3;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            Assert.Throws<ArgumentException>(
                () => new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void ThrowArgumentException_WhenThePassedCommentsIsNullOrWhitespaceString(string invalidComments)
        {
            int validGrade = 4;
            int validMinGrade = 3;
            int validMaxGrade = 3;

            Assert.Throws<ArgumentException>(
                () => new ExamResult(validGrade, validMinGrade, validMaxGrade, invalidComments));
        }

        [Test]
        public void CreateNewExamResultInstance_WhenPassedValidParameters()
        {
            int validGrade = 4;
            int validMinGrade = 2;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            var result = new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments);

            Assert.AreEqual("ExamResult", result.GetType().Name);
        }

        [Test]
        public void CorrectlyAssignGradeToProperty_WhenPassedValidParameters()
        {
            int validGrade = 4;
            int validMinGrade = 2;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            var result = new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments);

            Assert.AreEqual(4, result.Grade);
        }

        [Test]
        public void CorrectlyAssignMinGradeToProperty_WhenPassedValidParameters()
        {
            int validGrade = 4;
            int validMinGrade = 2;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            var result = new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments);

            Assert.AreEqual(2, result.MinGrade);
        }

        [Test]
        public void CorrectlyAssignMaxGradeToProperty_WhenPassedValidParameters()
        {
            int validGrade = 4;
            int validMinGrade = 2;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            var result = new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments);

            Assert.AreEqual(3, result.MaxGrade);
        }

        [Test]
        public void CorrectlyAssignCommentsToProperty_WhenPassedValidParameters()
        {
            int validGrade = 4;
            int validMinGrade = 2;
            int validMaxGrade = 3;
            string validComments = "Some comments";

            var result = new ExamResult(validGrade, validMinGrade, validMaxGrade, validComments);

            Assert.AreEqual("Some comments", result.Comments);
        }
    }
}

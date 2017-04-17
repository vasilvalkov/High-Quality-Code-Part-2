using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Exceptions_Homework.UnitTests.Fakes;

namespace Exceptions_Homework.UnitTests.Student_Tests
{
    [TestFixture]
    public class CalcAverageExamResultInPercents_Should
    {
        [Test]
        public void ReturnZero_WhenExamsIsEmptyCollection()
        {
            // Arrange
            string validFirstName = "Pesho";
            string validLastName = "Goshov";
            var student = new Student(validFirstName, validLastName);

            // Act
            var result = student.CalcAverageExamResultInPercents();

            // Assert
            Assert.Zero(result);
        }

        [Test]
        public void ReturnTheAverageOfAllGradesInExams_WhenExamsCollectionContainsExams()
        {
            // Arrange
            string validFirstName = "Pesho";
            string validLastName = "Goshov";

            var examResultFake = new FakeExamResult(4, 2, 6, "Comment");
            var examStub = new Mock<Exam>();
            examStub.Setup(e => e.Check()).Returns(examResultFake);

            var exams = new List<Exam> { examStub.Object };
            var student = new Student(validFirstName, validLastName, exams);

            double expected = (double)(4 - 2) / (6 - 2);

            // Act
            var result = student.CalcAverageExamResultInPercents();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

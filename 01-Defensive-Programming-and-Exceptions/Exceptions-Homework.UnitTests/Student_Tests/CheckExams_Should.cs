using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Exceptions_Homework.UnitTests.Fakes;

namespace Exceptions_Homework.UnitTests.Student_Tests
{
    [TestFixture]
    public class CheckExams_Should
    {
        [Test]
        public void ReturnNull_WhenExamsIsEmptyCollection()
        {
            // Arrange
            string validFirstName = "Pesho";
            string validLastName = "Goshov";
            var student = new Student(validFirstName, validLastName);

            // Act
            var result = student.CheckExams();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CallCheckMethodForEveryExamInExams_WhenInvoked()
        {
            // Arrange
            string validFirstName = "Pesho";
            string validLastName = "Goshov";
            var examMock = new Mock<Exam>();
            examMock.Setup(e => e.Check());

            var exams = new List<Exam> { examMock.Object };
            var student = new Student(validFirstName, validLastName, exams);

            // Act
            var result = student.CheckExams();

            // Assert
            examMock.Verify(e => e.Check(), Times.Once);
        }

        [Test]
        public void ReturnNewCollectionWithExamResults_WhenExamsCollectionContainsExams()
        {
            // Arrange
            string validFirstName = "Pesho";
            string validLastName = "Goshov";

            var examResultFake = new FakeExamResult(4, 0, 6, "Comment");
            var examStub = new Mock<Exam>();
            examStub.Setup(e => e.Check()).Returns(examResultFake);

            var exams = new List<Exam> { examStub.Object };
            var student = new Student(validFirstName, validLastName, exams);

            // Act
            var result = student.CheckExams();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(ExamResult));
        }
    }
}

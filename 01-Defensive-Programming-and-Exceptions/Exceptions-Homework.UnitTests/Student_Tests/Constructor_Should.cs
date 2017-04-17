using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Exceptions_Homework.UnitTests.Student_Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void ThrowArgumentException_WhenThePassedFirstNameIsNullOrWhiteSpace(string invalidFirstName)
        {
            string validLastName = "Goshov";

            Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, validLastName));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void ThrowArgumentException_WhenThePassedLastNameIsNullOrWhiteSpace(string invalidLastName)
        {
            string validFirstName = "Pesho";

            Assert.Throws<ArgumentException>(() => new Student(validFirstName, invalidLastName));
        }

        [Test]
        public void CreateNewStudentObject_WhenThePassedParametersAreValid()
        {
            string validFirstName = "Pesho";
            string validLastName = "Goshov";

            var result = new Student(validFirstName, validLastName);

            Assert.AreEqual("Student", result.GetType().Name);
        }

        [Test]
        public void CorrectlyAssignFirstNameProperty_WhenThePassedParametersArevalid()
        {
            string validFirstName = "Pesho";
            string validLastName = "Goshov";

            var result = new Student(validFirstName, validLastName);

            Assert.AreEqual("Pesho", result.FirstName);
        }

        [Test]
        public void CorrectlyAssignLastNameProperty_WhenThePassedParametersArevalid()
        {
            string validFirstName = "Pesho";
            string validLastName = "Goshov";

            var result = new Student(validFirstName, validLastName);

            Assert.AreEqual("Goshov", result.LastName);
        }

        [Test]
        public void CorrectlyAssignExamsProperty_WhenExamsArePassedAsParameter()
        {
            string validFirstName = "Pesho";
            string validLastName = "Goshov";
            var examStub = new Mock<Exam>();
            var exams = new List<Exam> { examStub.Object };

            var result = new Student(validFirstName, validLastName, exams);

            Assert.AreSame(exams, result.Exams);
        }

        [Test]
        public void CorrectlyAssignExamsPropertyWithEmptyCollection_WhenExamsArePassedAsParameter()
        {
            string validFirstName = "Pesho";
            string validLastName = "Goshov";
            var examStub = new Mock<Exam>();
            var exams = new List<Exam> { examStub.Object };

            var result = new Student(validFirstName, validLastName);

            CollectionAssert.IsEmpty(result.Exams);
        }
    }
}

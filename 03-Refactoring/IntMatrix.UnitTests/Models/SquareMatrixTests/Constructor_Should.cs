using NUnit.Framework;
using IntMatrix.Models;
using System;

namespace IntMatrix.UnitTests.Models.SquareMatrixTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenThePassedArgumentIsValid()
        {
            int validSize = 4;

            Assert.DoesNotThrow(() => new SquareMatrix(validSize));
        }

        [Test]
        public void ReturnNewSquareMatrixObject_WhenThePassedArgumentIsValid()
        {
            int validSize = 4;

            var result = new SquareMatrix(validSize);

            Assert.AreEqual("SquareMatrix", result.GetType().Name);
        }

        [Test]
        public void SetAllPropertiesCorrectly_WhenThePassedArgumentIsValid()
        {
            int validSize = 4;
            var expectedField = new int[4, 4];

            var result = new SquareMatrix(validSize);

            Assert.AreEqual(result.Size, validSize);
            Assert.AreEqual(result.Field, expectedField);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void ThrowArgumentException_WhenThePassedArgumentIsSmallerThaOne(int invalidSize)
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix(invalidSize));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedArgumentIsGreaterThanIntMaxValue()
        {
            var max = int.MaxValue;
            int invalidSize = max + 1;

            Assert.Throws<ArgumentException>(() => new SquareMatrix(invalidSize));
        }
    }
}

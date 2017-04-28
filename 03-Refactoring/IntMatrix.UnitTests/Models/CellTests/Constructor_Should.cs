using NUnit.Framework;
using IntMatrix.Models;
using System;

namespace IntMatrix.UnitTests.Models.CellTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            Assert.DoesNotThrow(() => new Cell(validRow, validColumn));
        }

        [Test]
        public void ReturnNewCellObject_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            var result = new Cell(validRow, validColumn);

            Assert.AreEqual("Cell", result.GetType().Name);
        }

        [Test]
        public void SetAllPropertiesCorrectly_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            var result = new Cell(validRow, validColumn);

            Assert.AreEqual(result.Row, validRow);
            Assert.AreEqual(result.Col, validColumn);
        }

        [Test]
        public void ThrowArgumentException_WhenPassedRowIsNegative()
        {
            int negativeRow = -1;
            int validColumn = 1;
            
            Assert.Throws<ArgumentException>(() => new Cell(negativeRow, validColumn));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedColumnIsNegative()
        {
            int validRow = 1;
            int negativeColumn = -1;

            Assert.Throws<ArgumentException>(() => new Cell(validRow, negativeColumn));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedRowIsGreaterThanInMaxValue()
        {
            int validColumn = 1;
            var max = int.MaxValue;
            int invalidRow = max + 1;

            Assert.Throws<ArgumentException>(() => new Cell(invalidRow, validColumn));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedColIsGreaterThanInMaxValue()
        {
            int validRow = 1;
            var max = int.MaxValue;
            int invalidColumn = max + 1;

            Assert.Throws<ArgumentException>(() => new Cell(validRow, invalidColumn));
        }
    }
}

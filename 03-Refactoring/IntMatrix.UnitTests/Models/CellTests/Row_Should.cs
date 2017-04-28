using IntMatrix.Models;
using NUnit.Framework;
using System;

namespace IntMatrix.UnitTests.Models.CellTests
{
    [TestFixture]
    public class Row_Should
    {
        [TestCase(10)]
        [TestCase(0)]
        [TestCase(10000)]
        public void CorrectlyAssignNewValue_WhenThePassedValueIsValid(int validValue)
        {
            int validRow = 1;
            int validColumn = 1;
            var cell = new Cell(validRow, validColumn);

            cell.Row = validValue;

            Assert.AreEqual(cell.Row, validValue);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedValueIsNegative()
        {
            int validRow = 1;
            int validColumn = 1;
            var cell = new Cell(validRow, validColumn);

            Assert.Throws<ArgumentException>(() => cell.Row = -1);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedValueIsGreaterThanIntMaxValue()
        {
            int validRow = 1;
            int validColumn = 1;
            var cell = new Cell(validRow, validColumn);
            var max = int.MaxValue;

            Assert.Throws<ArgumentException>(() => cell.Row = (max + 1));
        }
    }
}

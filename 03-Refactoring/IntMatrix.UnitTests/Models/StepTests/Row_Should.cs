using IntMatrix.Models;
using NUnit.Framework;

namespace IntMatrix.UnitTests.Models.StepTests
{
    [TestFixture]
    public class Row_Should
    {
        [TestCase(10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10000)]
        public void CorrectlyAssignNewValue_Always(int passedValue)
        {
            int validRow = 1;
            int validColumn = 1;
            var step = new Step(validRow, validColumn);

            step.Row = passedValue;

            Assert.AreEqual(step.Row, passedValue);
        }
    }
}

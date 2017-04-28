using IntMatrix.Models;
using NUnit.Framework;

namespace IntMatrix.UnitTests.Models.StepTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            Assert.DoesNotThrow(() => new Step(validRow, validColumn));
        }

        [Test]
        public void ReturnNewStepObject_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            var result = new Step(validRow, validColumn);

            Assert.AreEqual("Step", result.GetType().Name);
        }

        [Test]
        public void SetAllPropertiesCorrectly_WhenAllPassedArgumentsAreValid()
        {
            int validRow = 1;
            int validColumn = 1;

            var result = new Step(validRow, validColumn);

            Assert.AreEqual(result.Row, validRow);
            Assert.AreEqual(result.Col, validColumn);
        }        
    }
}

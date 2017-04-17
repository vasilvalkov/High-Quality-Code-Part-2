using Exceptions_Homework;
using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.ExceptionsHomework_Tests
{
    [TestFixture]
    public class ExtractEnding_Should
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void ThrowArgumentException_WhenThePassedStringIsNullOrWhitespace(string inputString)
        {
            int validCount = 1;

            Assert.Throws<ArgumentException>(() => ExceptionsHomework.ExtractEnding(inputString, validCount));
        }

        [Test]
        public void ReturnNewSubstringConsistingOfCountNumberOfCharactersFromTheEnding_WhenThePassedParametersAreValid()
        {
            string validInputString = "Valid input string";
            int validCount = 6;
            string expected = "string";

            string result = ExceptionsHomework.ExtractEnding(validInputString, validCount);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnEmptyString_WhenThePassedCountIsZero()
        {
            string validInputString = "Valid input string";
            int validCount = 0;
            string expected = string.Empty;

            string result = ExceptionsHomework.ExtractEnding(validInputString, validCount);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnEmptyString_WhenThePassedCountIsNegative()
        {
            string validInputString = "Valid input string";
            int validCount = -1;
            string expected = string.Empty;

            string result = ExceptionsHomework.ExtractEnding(validInputString, validCount);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnTheWholeInputString_WhenThePassedCountIsGreaterThanInputStringLength()
        {
            string validInputString = "Valid";
            int validCount = 10;
            string expected = "Valid";

            string result = ExceptionsHomework.ExtractEnding(validInputString, validCount);

            Assert.AreEqual(expected, result);
        }
    }
}

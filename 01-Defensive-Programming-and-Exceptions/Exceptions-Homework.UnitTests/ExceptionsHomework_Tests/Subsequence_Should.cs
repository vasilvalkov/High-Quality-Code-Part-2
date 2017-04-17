using Exceptions_Homework;
using NUnit.Framework;
using System;

namespace ExceptionsHomework_UnitTests.ExceptionsHomework_Tests
{
    [TestFixture]
    public class Subsequence_Should
    {
        [Test]
        public void ThrowArgumentException_WhenThePassedCollectionIsNull()
        {
            // Arrange
            int validStartIndex = 0;
            int validCount = 2;

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(null, validStartIndex, validCount));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedCollectionHasNoElements()
        {
            // Arrange
            int validStartIndex = 0;
            int validCount = 2;
            int[] arrayWithoutElements = new int[0];

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(arrayWithoutElements, validStartIndex, validCount));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedStartIndexIsNegative()
        {
            // Arrange
            int negativeStartIndex = -1;
            int validCount = 2;
            int[] validCollection = new int[4];

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(validCollection, negativeStartIndex, validCount));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedStartIndexIsGreaterThanTheCollectionLength()
        {
            // Arrange
            int greaterStartIndex = 10;
            int validCount = 2;
            int[] validCollection = new int[4];

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(validCollection, greaterStartIndex, validCount));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedCountIsNegative()
        {
            // Arrange
            int validStartIndex = 0;
            int negativeCount = -1;
            int[] validCollection = new int[4];

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(validCollection, validStartIndex, negativeCount));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedCountIsGreaterThanTheCollectionLength()
        {
            // Arrange
            int validStartIndex = 0;
            int greaterCount = 10;
            int[] validCollection = new int[4];

            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => ExceptionsHomework.Subsequence<int>(validCollection, validStartIndex, greaterCount));
        }

        [Test]
        public void ReturnElementsFromStartIndexToEndOfCollection_WhenTheSumOfThePassedStartIndexAndCountIsGreaterThanTheCollectionLength()
        {
            // Arrange
            int validStartIndex = 2;
            int validCount = 3;
            int[] validCollection = new int[] { 1, 2, 3, 4 };
            int[] expectedCollection = new int[] { 3, 4 };

            // Act
            var result = ExceptionsHomework.Subsequence<int>(validCollection, validStartIndex, validCount);
            // Assert
            Assert.AreEqual(expectedCollection, result);
        }

        [Test]
        public void ReturnNewCollectionWhichIsCountElementsSubsequenceFromStartIndex_WhenAllPassedParametersAreValid()
        {
            // Arrange
            int validStartIndex = 0;
            int validCount = 3;
            int[] validCollection = new int[] { 1, 2, 3, 4 };
            int[] expectedCollection = new int[] { 1, 2, 3 };

            // Act
            var result = ExceptionsHomework.Subsequence<int>(validCollection, validStartIndex, validCount);
            // Assert
            Assert.AreEqual(expectedCollection, result);
        }

        [Test]
        public void ReturnNewCollection_WhenAllPassedParametersAreValid()
        {
            // Arrange
            int validStartIndex = 0;
            int validCount = 4;
            int[] validCollection = new int[] { 1, 2, 3, 4 };
            int[] expectedCollection = new int[] { 1, 2, 3, 4 };

            // Act
            var result = ExceptionsHomework.Subsequence<int>(validCollection, validStartIndex, validCount);
            // Assert
            Assert.AreNotSame(expectedCollection, result);
        }
    }
}

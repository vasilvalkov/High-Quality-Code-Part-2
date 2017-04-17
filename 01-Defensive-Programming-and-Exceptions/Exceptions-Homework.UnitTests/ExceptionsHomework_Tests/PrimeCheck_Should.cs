using Exceptions_Homework;
using NUnit.Framework;
using System;

namespace Exceptions_Homework.UnitTests.ExceptionsHomework_Tests
{
    [TestFixture]
    public class PrimeCheck_Should
    {
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-33)]
        public void ThrowArgumentException_WhenThePassedNumberIsSmallerThanTwo(int invalidNumber)
        {
            Assert.Throws<ArgumentException>(() => ExceptionsHomework.CheckPrime(invalidNumber));
        }

        [TestCase(2)]
        [TestCase(7)]
        [TestCase(1000)]
        public void NotThrow_WhenThePassedNumberIsValid(int validNumber)
        {
            Assert.DoesNotThrow(() => ExceptionsHomework.CheckPrime(validNumber));
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(23)]
        [TestCase(113)]
        public void ReturnTrue_WhenThePassedNumberIsPrime(int primeNumber)
        {
            bool isPrime = ExceptionsHomework.CheckPrime(primeNumber);

            Assert.IsTrue(isPrime);
        }

        [TestCase(4)]
        [TestCase(9)]
        [TestCase(27)]
        [TestCase(1000)]
        public void ReturnFalse_WhenThePassedNumberIsNotPrime(int nonprimeNumber)
        {
            bool isPrime = ExceptionsHomework.CheckPrime(nonprimeNumber);

            Assert.IsFalse(isPrime);
        }
    }
}

using NUnit.Framework;
using IntMatrix.Models;
using System;
using IntMatrix.Models.Contracts;
using Moq;

namespace IntMatrix.UnitTests.Models.SquareMatrixFillerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenThePassedArgumentsAreValid()
        {
            var matrixStub = new Mock<ISquareMatrix>();
            var cellStub = new Mock<ICell>();

            Assert.DoesNotThrow(() => new SquareMatrixFiller(matrixStub.Object, cellStub.Object, cellStub.Object));
        }

        [Test]
        public void ReturnNewSquareMatrixFillerObject_WhenThePassedArgumentsAreValid()
        {
            var matrixStub = new Mock<ISquareMatrix>();
            var cellStub = new Mock<ICell>();

            var result = new SquareMatrixFiller(matrixStub.Object, cellStub.Object, cellStub.Object);

            Assert.AreEqual("SquareMatrixFiller", result.GetType().Name);
        }

        [Test]
        public void SetAllPropertiesCorrectly_WhenThePassedArgumentsAreValid()
        {
            var matrixStub = new Mock<ISquareMatrix>();
            var cellStub = new Mock<ICell>();

            var result = new SquareMatrixFiller(matrixStub.Object, cellStub.Object, cellStub.Object);

            Assert.AreSame(result.Matrix, matrixStub.Object);
            Assert.AreSame(result.CurrentCell, cellStub.Object);
            Assert.AreSame(result.NextCell, cellStub.Object);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedMatrixArgumentIsNull()
        {
            var cellStub = new Mock<ICell>();

            Assert.Throws<ArgumentException>(() => new SquareMatrixFiller(null, cellStub.Object, cellStub.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedCurrentCellArgumentIsNull()
        {
            var matrixStub = new Mock<ISquareMatrix>();
            var cellStub = new Mock<ICell>();

            Assert.Throws<ArgumentException>(() => new SquareMatrixFiller(matrixStub.Object, null, cellStub.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedNextCellArgumentIsNull()
        {
            var matrixStub = new Mock<ISquareMatrix>();
            var cellStub = new Mock<ICell>();

            Assert.Throws<ArgumentException>(() => new SquareMatrixFiller(matrixStub.Object, cellStub.Object, null));
        }
    }
}

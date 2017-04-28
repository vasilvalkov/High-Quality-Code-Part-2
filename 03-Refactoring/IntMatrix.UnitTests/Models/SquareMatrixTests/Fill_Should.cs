using NUnit.Framework;
using IntMatrix.Models;
using System;
using IntMatrix.Models.Contracts;
using Moq;

namespace IntMatrix.UnitTests.Models.SquareMatrixTests
{
    [TestFixture]
    public class Fill_Should
    {
        [Test]
        public void PopulateTheMatrixWithNumbersFromOneToThePowerOfMatrixSizeMinusOne_WhenInvoked()
        {
            // Arrange
            int matrixSize = 7;
            var matrixMock = new Mock<ISquareMatrix>();
            matrixMock.Setup(m => m.Size).Returns(matrixSize);
            matrixMock.Setup(m => m.Field).Returns(new int[matrixSize, matrixSize]);

            var currentCellStub = new Mock<ICell>();
            var nextCellStub = new Mock<ICell>();
            var filler = new SquareMatrixFiller(matrixMock.Object, currentCellStub.Object, nextCellStub.Object);

            // Act
            filler.Fill();

            int maxNumber = default(int);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrixMock.Object.Field[row, col] > maxNumber)
                    {
                        maxNumber = matrixMock.Object.Field[row, col];
                    }
                }
            }

            // Assert
            Assert.AreEqual(maxNumber, (matrixSize * matrixSize) - 1);
        }

        [Test]
        public void PopulateMatrixTopLeftBottomRightDiagonalWithNumbersFromOneToMatrixSize_WhenInvoked()
        {
            // Arrange
            int matrixSize = 7;
            var matrixMock = new Mock<ISquareMatrix>();
            matrixMock.Setup(m => m.Size).Returns(matrixSize);
            matrixMock.Setup(m => m.Field).Returns(new int[matrixSize, matrixSize]);

            var currentCellStub = new Mock<ICell>();
            var nextCellStub = new Mock<ICell>();
            var filler = new SquareMatrixFiller(matrixMock.Object, currentCellStub.Object, nextCellStub.Object);

            // Act
            filler.Fill();

            // Assert
            Assert.AreEqual(matrixMock.Object.Field[0, 0], 1);
            Assert.AreEqual(matrixMock.Object.Field[1, 1], 2);
            Assert.AreEqual(matrixMock.Object.Field[2, 2], 3);
            Assert.AreEqual(matrixMock.Object.Field[3, 3], 4);
            Assert.AreEqual(matrixMock.Object.Field[4, 4], 5);
            Assert.AreEqual(matrixMock.Object.Field[5, 5], 6);
            Assert.AreEqual(matrixMock.Object.Field[6, 6], 7);

        }
    }
}

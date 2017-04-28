using IntMatrix.Models.Contracts;
using System;

namespace IntMatrix.Models
{
    public class SquareMatrixFiller : ISquareMatrixFiller
    {
        private static readonly int[] DirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] DirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private ISquareMatrix matrix;
        private ICell currentCell;
        private ICell nextCell;

        public SquareMatrixFiller(ISquareMatrix matrix, ICell currentCell, ICell nextCell)
        {
            this.Matrix = matrix;
            this.CurrentCell = currentCell;
            this.NextCell = nextCell;
        }

        public ISquareMatrix Matrix
        {
            get
            {
                return this.matrix;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The provided matrix cannot be null!");
                }

                this.matrix = value;
            }
        }

        public ICell CurrentCell
        {
            get
            {
                return this.currentCell;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The current cell cannot be null!");
                }

                this.currentCell = value;
            }
        }

        public ICell NextCell
        {
            get
            {
                return this.nextCell;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The next cell cannot be null!");
                }

                this.nextCell = value;
            }
        }

        public void Fill()
        {
            int currentValue = 1;

            this.FillCells(this.Matrix, this.CurrentCell, this.NextCell, ref currentValue);

            this.FindEmptyCell(this.Matrix.Field, this.CurrentCell);

            if (this.CurrentCell.Row != 0 && this.CurrentCell.Col != 0)
            {
                this.NextCell.Row = 1;
                this.NextCell.Col = 1;

                this.FillCells(this.Matrix, this.CurrentCell, this.NextCell, ref currentValue);
            }
        }

        private void ChangeDirection(ICell cell)
        {
            int currentDirection = 0;
            int lastDirection = DirX.Length - 1;

            for (int i = 0; i < DirX.Length; i++)
            {
                if (DirX[i] == cell.Row && DirY[i] == cell.Col)
                {
                    currentDirection = i;
                    break;
                }
            }

            if (currentDirection == lastDirection)
            {
                cell.Row = DirX[0];
                cell.Col = DirY[0];
                return;
            }

            cell.Row = DirX[currentDirection + 1];
            cell.Col = DirY[currentDirection + 1];
        }

        private bool CheckIfBoundaryReached(int[,] matrix, int nextStepX, int nextStepY)
        {
            for (int i = 0; i < DirX.Length; i++)
            {
                if (nextStepX + DirX[i] >= matrix.GetLength(0) || nextStepX + DirX[i] < 0)
                {
                    return true;
                }

                if (nextStepY + DirY[i] >= matrix.GetLength(1) || nextStepY + DirY[i] < 0)
                {
                    return true;
                }

                if (matrix[nextStepX + DirX[i], nextStepY + DirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FillCells(ISquareMatrix matrix, ICell currentCell, ICell nextCell, ref int currentValue)
        {
            while (true)
            {
                matrix.Field[currentCell.Row, currentCell.Col] = currentValue;

                bool matrixBoundaryReached = this.CheckIfBoundaryReached(matrix.Field, currentCell.Row, currentCell.Col);

                if (!matrixBoundaryReached)
                {
                    break;
                }

                bool steppedOutside = this.CheckIfSteppedOutsideOfMatrix(matrix, currentCell, nextCell);

                while (steppedOutside)
                {
                    this.ChangeDirection(nextCell);
                    steppedOutside = this.CheckIfSteppedOutsideOfMatrix(matrix, currentCell, nextCell);
                }

                currentCell.Row += nextCell.Row;
                currentCell.Col += nextCell.Col;
                currentValue++;
            }
        }

        private bool CheckIfSteppedOutsideOfMatrix(ISquareMatrix matrix, ICell currentCell, ICell nextCell)
        {
            bool steppedOusideRight = currentCell.Row + nextCell.Row >= matrix.Size;
            bool steppedOusideLeft = currentCell.Row + nextCell.Row < 0;
            bool steppedOusideBottom = currentCell.Col + nextCell.Col >= matrix.Size;
            bool steppedOutsideTop = currentCell.Col + nextCell.Col < 0;
            bool steppedOuside = steppedOusideRight || steppedOusideLeft || steppedOusideBottom || steppedOutsideTop;
            bool isPopulated = false;

            if (!steppedOuside)
            {
                isPopulated = matrix.Field[currentCell.Row + nextCell.Row, currentCell.Col + nextCell.Col] != 0;
            }

            return steppedOuside || isPopulated;
        }

        private void FindEmptyCell(int[,] matrix, ICell currentCell)
        {
            int emptyCell = 0;
            currentCell.Row = 0;
            currentCell.Col = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == emptyCell)
                    {
                        currentCell.Row = row;
                        currentCell.Col = col;

                        return;
                    }
                }
            }
        }
    }
}
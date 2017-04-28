using IntMatrix.Models.Contracts;
using System;

namespace IntMatrix.Models
{
    public class SquareMatrix : ISquareMatrix
    {
        private int size;
        private int[,] field;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.field = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The size of the matrix cannot be less than 1!");
                }

                if (value > int.MaxValue)
                {
                    throw new ArgumentException(string.Format("The size of the matrix cannot be greater than {0}", int.MaxValue));
                }

                this.size = value;
            }
        }

        public int[,] Field
        {
            get
            {
                return this.field;
            }
        }
    }
}

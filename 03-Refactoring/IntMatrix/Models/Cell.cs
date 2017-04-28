using IntMatrix.Models.Contracts;
using System;

namespace IntMatrix.Models
{
    public class Cell : ICell
    {
        private int row;
        private int col;

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Row number cannot be negative!");
                }

                if (value > int.MaxValue)
                {
                    throw new ArgumentException(string.Format("Row number cannot be greater than {0}", int.MaxValue));
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Column number cannot be negative!");
                }

                if (value > int.MaxValue)
                {
                    throw new ArgumentException(string.Format("Column number cannot be greater than {0}", int.MaxValue));
                }

                this.col = value;
            }
        }
    }
}

using IntMatrix.Models.Contracts;

namespace IntMatrix.Models
{
    public class Step : ICell
    {
        public Step(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col { get; set; }

        public int Row { get; set; }
    }
}

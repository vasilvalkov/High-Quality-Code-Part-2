using IntMatrix.Models;
using IntMatrix.Models.Contracts;
using IntMatrix.Providers;
using IntMatrix.Providers.Contracts;

namespace IntMatrix
{
    public class Startup
    {
        private const int MIN_SIZE_OF_MATRIX = 0;
        private const int MAX_SOZE_OF_MATRIX = 100;

        public static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            writer.WriteLine("Enter a positive number ");

            int numberOfRows = ReadMatrixSize(writer, reader);

            ISquareMatrix matrix = new SquareMatrix(numberOfRows);
            ICell currentCell = new Cell(0, 0);
            ICell nextStep = new Step(1, 1);

            ISquareMatrixFiller matrixFiller = new SquareMatrixFiller(matrix, currentCell, nextStep);

            matrixFiller.Fill();

            PrintMatrix(writer, matrix.Field);
        }

        private static int ReadMatrixSize(IWriter writer, IReader reader)
        {
            int numberOfRows = 0;
            string input = reader.ReadLine();

            while (!int.TryParse(input, out numberOfRows) ||
                numberOfRows < MIN_SIZE_OF_MATRIX ||
                numberOfRows > MAX_SOZE_OF_MATRIX)
            {
                writer.WriteLine("You haven't entered a correct positive number");
                input = reader.ReadLine();
            }

            return numberOfRows;
        }

        private static void PrintMatrix(IWriter writer, int[,] matrix)
        {
            int largestNumberInMatrix = (matrix.GetLength(0) * matrix.GetLength(1)) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string number = matrix[row, col]
                                        .ToString()
                                        .PadLeft(largestNumberInMatrix.ToString().Length + 1, ' ');

                    writer.Write(number);
                }

                writer.WriteLine();
            }
        }
    }
}

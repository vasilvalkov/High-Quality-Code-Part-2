namespace IntMatrix.Models.Contracts
{
    public interface ISquareMatrix
    {
        int Size { get; }

        int[,] Field { get; }
    }
}
namespace IntMatrix.Models.Contracts
{
    public interface ISquareMatrixFiller
    {
        ISquareMatrix Matrix { get; }

        ICell CurrentCell { get; }

        ICell NextCell { get; }

        void Fill();
    }
}

using SchoolSystem.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Models.Contracts
{
    public interface IStudent : IPerson
    {
        Grade Grade { get; }

        IList<IMark> Marks { get; }

        string ListMarks();
    }
}

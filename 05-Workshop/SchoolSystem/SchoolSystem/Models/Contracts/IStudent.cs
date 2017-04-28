using SchoolSystem.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Models.Contracts
{
    public interface IStudent
    {
        Grade Grade { get; }

        IList<IMark> Marks { get; }
    }
}

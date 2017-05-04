﻿using SchoolSystem.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Represents a school student.
    /// </summary>
    public interface IStudent : IPerson
    {
        /// <summary>
        /// The grade of the student.
        /// </summary>
        Grade Grade { get; }

        /// <summary>
        /// The makrs obtained by the student.
        /// </summary>
        IList<IMark> Marks { get; }        
    }
}

using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Represents a school teacher.
    /// </summary>
    public interface ITeacher : IPerson
    {
        /// <summary>
        /// Represents the subject the teacher is teaching.
        /// </summary>
        Subjct Subject { get; }

        /// <summary>
        /// Appraise a student.
        /// </summary>
        /// <param name="student">The student that is being appraised.</param>
        /// <param name="mark">The mark value.</param>
        void AddMark(IStudent student, float mark);
    }
}

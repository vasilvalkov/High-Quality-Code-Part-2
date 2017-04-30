using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Represents a school mark for student appraisal.
    /// </summary>
    public interface IMark
    {
        /// <summary>
        /// The subject the mark is in.
        /// </summary>
        Subjct Subject { get; }

        /// <summary>
        /// The value of the mark.
        /// </summary>
        float Value { get; }
    }
}

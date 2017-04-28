using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface ITeacher
    {
        Subjct Subject { get; }

        void AddMark(IStudent student, float mark);
    }
}

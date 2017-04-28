using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface ITeacher : IPerson
    {
        Subjct Subject { get; }

        void AddMark(IStudent student, float mark);
    }
}

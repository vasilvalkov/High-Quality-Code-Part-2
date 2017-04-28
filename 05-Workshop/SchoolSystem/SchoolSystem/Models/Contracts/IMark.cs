using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface IMark
    {
        Subjct Subject { get; }

        float Value { get; }
    }
}

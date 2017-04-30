namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Defines the names for a person.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// The first Name of the person.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// The last or family name of the person.
        /// </summary>
        string LastName { get; }
    }
}
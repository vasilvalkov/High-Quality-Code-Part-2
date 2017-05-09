namespace ProjectManager.Models.Contracts
{
    public interface IUser
    {
        string Email { get; set; }

        string Username { get; set; }
    }
}
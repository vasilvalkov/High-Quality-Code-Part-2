using ProjectManager.Commands;
using ProjectManager.Data;

namespace ProjectManager.Core.Factories
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}
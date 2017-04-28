using System.Collections.Generic;

namespace SchoolSystem.Core.Commands.Contracts
{
    interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}

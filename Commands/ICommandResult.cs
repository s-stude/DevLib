using System.Collections.Generic;

namespace DevLib.Infrastructure.Commands
{
    public interface ICommandResult
    {
        CommandResultType ResultType { get; set; }
        IList<string> Errors { get; set; }
    }
}
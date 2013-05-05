using System.Collections.Generic;

namespace DevLib.Infrastructure.Commands.Impl
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            Errors = new List<string>();
        }

        public CommandResult(CommandResultType resultType) : this()
        {
            ResultType = resultType;
        }

        public CommandResultType ResultType { get; set; }
        public IList<string> Errors { get; set; }
    }
}
using System.Collections.Generic;

namespace DevLib.Infrastructure.Commands
{
    public class CommandResult
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
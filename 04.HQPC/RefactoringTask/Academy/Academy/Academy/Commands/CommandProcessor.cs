using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IParser parser;

        public CommandProcessor(IParser parser)
        {
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            return executionResult;
        }
    }
}

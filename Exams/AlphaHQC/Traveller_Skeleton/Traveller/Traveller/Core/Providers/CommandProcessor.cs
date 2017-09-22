using Bytes2you.Validation;
using System;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
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

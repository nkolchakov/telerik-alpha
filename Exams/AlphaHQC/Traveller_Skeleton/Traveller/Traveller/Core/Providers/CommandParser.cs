using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "fullcommand").IsNull().Throw();

            var commandName = fullCommand.Split()[0];
            var command = this.factory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "fullcommand").IsNull().Throw();

            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}

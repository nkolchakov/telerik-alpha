using MetaEditor.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaEditor.Commands.Contracts;
using MetaEditor.Core.Factories;

namespace MetaEditor.Utils
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            this.factory = factory;
        }

        public ICommand CreateCommand(string fullCommand)
        {
            string commandName = fullCommand.Split(new char[] { ' ' }, 2)[0];
            var command = this.factory.CreateCommand(commandName);
            return command;
        }

        public IList<string> ParseParamters(string fullCommand)
        {
            var parameters = fullCommand.Split(new char[]{' '},2)
                .Skip(1)
                .ToArray();

            return parameters;
        }
    }
}

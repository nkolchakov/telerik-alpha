using MetaEditor.Commands.Contracts;
using MetaEditor.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IParser parser;

        public CommandProcessor(IParser parser)
        {
            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            var command = this.parser.CreateCommand(commandAsString);
            var parameters = this.parser.ParseParamters(commandAsString);

            string executionResult = command.Execute(parameters);

            return executionResult;

        }
    }
}

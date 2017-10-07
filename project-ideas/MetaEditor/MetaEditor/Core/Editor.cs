using MetaEditor.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaEditor.Commands.Contracts;
using MetaEditor.Utils;

namespace MetaEditor.Core
{
    public class Editor : IEditor
    {
        private readonly ICommandProcessor processor;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Editor(ICommandProcessor processor, IWriter writer, IReader reader)
        {
            this.processor = processor;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string commandAsStr;
            while ((commandAsStr = this.reader.Read()) != Constants.ExitCommand)
            {
                string executionResult = this.processor.ProcessCommand(commandAsStr);
                this.writer.Write(executionResult);
            }
        }
    }
}

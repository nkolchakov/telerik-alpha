using Bytes2you.Validation;
using System;
using Traveller.Core.Contracts;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IDatabase database;
        private readonly ICommandProcessor processor;

        public Engine(IReader reader, IWriter writer, IDatabase database, ICommandProcessor processor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();
            
            this.reader = reader;
            this.writer = writer;
            this.database = database;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.Read();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.database.TextResult.ToString());
                        break;
                    }

                    string executionResult = this.processor.ProcessCommand(commandAsString);
                    this.database.TextResult.AppendLine(executionResult);
                }
                catch (Exception ex)
                {
                    this.database.TextResult.AppendLine(ex.Message);
                }
            }
        }
    }
}

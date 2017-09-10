using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Database;
using Bytes2you.Validation;
using System;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;
        private readonly IDatabase database;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor, IDatabase database)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "commandProcessor").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
            this.database = database;
        }
        
        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(string.Join("\n",this.database.ExecutionResult));
                        break;
                    }

                    string executionResult = this.commandProcessor.ProcessCommand(commandAsString);

                    this.database.ExecutionResult.Add(executionResult);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.database.ExecutionResult.Add("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.database.ExecutionResult.Add(ex.Message);
                }
            }
        }

        // moved to CommandProcessor class

        //private void ProcessCommand(string commandAsString)
        //{
        //    if (string.IsNullOrWhiteSpace(commandAsString))
        //    {
        //        throw new ArgumentNullException("Command cannot be null or empty.");
        //    }

        //    var command = this.Parser.ParseCommand(commandAsString);
        //    var parameters = this.Parser.ParseParameters(commandAsString);

        //    var executionResult = command.Execute(parameters);
        //    this.builder.AppendLine(executionResult);
        //}
    }
}

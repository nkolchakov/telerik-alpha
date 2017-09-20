using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Utils;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Decorator
{
    public class LogCreateCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IWriter writer;
        private readonly IDateTimeProvider dateTimeProvider;

        public LogCreateCommandDecorator(ICommand command, IWriter writer, IDateTimeProvider dateTimeProvider)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider").IsNull().Throw();

            this.command = command;
            this.writer = writer;
            this.dateTimeProvider = dateTimeProvider;
        }

        public string Execute(IList<string> parameters)
        {
            this.writer.Write($"--- {this.command.GetType().Name} is called at {this.dateTimeProvider.DateTimeNow()}!");
            return this.command.Execute(parameters);
        }
    }
}

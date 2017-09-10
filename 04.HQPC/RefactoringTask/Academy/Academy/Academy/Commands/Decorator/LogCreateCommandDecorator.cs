using Academy.Commands.Contracts;
using Academy.Utils;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Decorator
{
    public class LogCreateCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IDateTimeProvider dateTimeProvider;

        public LogCreateCommandDecorator(ICommand command, IDateTimeProvider dateTimeProvider)
        {
            this.command = command;
            this.dateTimeProvider = dateTimeProvider;
        }

        public string Execute(IList<string> parameters)
        {
            Console.WriteLine($"--- {this.command.GetType().Name} is called at {this.dateTimeProvider.DateTimeNow()}!");
            return this.command.Execute(parameters);
        }
    }
}

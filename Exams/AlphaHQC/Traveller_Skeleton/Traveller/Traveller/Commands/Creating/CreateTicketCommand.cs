﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly ITravellerFactory travellerFactory;
        private readonly IDatabase database;

        public CreateTicketCommand(ITravellerFactory travellerFactory, IDatabase database)
        {
            Guard.WhenArgument(travellerFactory, "travellerFactory").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.travellerFactory = travellerFactory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.database.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            ITicket ticket = this.travellerFactory.CreateTicket(journey, administrativeCosts);

            this.database.Tickets.Add(ticket);

            return $"Ticket with ID {this.database.Tickets.Count - 1} was created.";
        }
    }
}

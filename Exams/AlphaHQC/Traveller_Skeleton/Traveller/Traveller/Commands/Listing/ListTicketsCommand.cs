using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ListingCommand<ITicket>, ICommand
    {
        public ListTicketsCommand(IDatabase database)
            : base(database)
        {
        }

        protected override IList<ITicket> Collection
        {
            get
            {
                return this.Database.Tickets;
            }
        }

        protected override string EmptyCollectionMessage
        {
            get
            {
                return "There are no registered tickets.";
            }
        }
    }
}

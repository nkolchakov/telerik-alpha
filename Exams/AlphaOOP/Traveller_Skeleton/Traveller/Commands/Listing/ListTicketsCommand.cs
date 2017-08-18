using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ListingCommand<ITicket>, ICommand
    {
        public ListTicketsCommand(ITravellerFactory factory, IEngine engine) 
            : base(factory, engine)
        {
        }

        protected override ICollection<ITicket> Items
        {
            get
            {
                return this.engine.Tickets;
            }
        }

        protected override string CustomErrorMessage
        {
            get
            {
                return "There are no registered tickets.";

            }
        }
    }
}

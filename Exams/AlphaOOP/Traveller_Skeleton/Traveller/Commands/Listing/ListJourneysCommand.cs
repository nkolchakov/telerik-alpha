using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ListingCommand<IJourney>, ICommand
    {
        public ListJourneysCommand(ITravellerFactory factory, IEngine engine) 
            : base(factory, engine)
        {
        }

        protected override ICollection<IJourney> Items
        {
            get
            {
                return this.engine.Journeys;
            }
        }

        protected override string CustomErrorMessage
        {
            get
            {
                return "There are no registered journeys.";
            }
        }
    }
}

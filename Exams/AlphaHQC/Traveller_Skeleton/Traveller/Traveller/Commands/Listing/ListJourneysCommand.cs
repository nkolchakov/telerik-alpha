using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ListingCommand<IJourney>, ICommand
    {
        public ListJourneysCommand(IDatabase database)
            : base(database)
        {
        }

        protected override IList<IJourney> Collection
        {
            get
            {
                return this.Database.Journeys;
            }
        }

        protected override string EmptyCollectionMessage
        {
            get
            {
                return "There are no registered journeys.";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ListingCommand<IVehicle>, ICommand
    {
        public ListVehiclesCommand(IDatabase database)
            : base(database)
        {
        }

        protected override IList<IVehicle> Collection
        {
            get
            {
                return this.Database.Vehicles;
            }
        }

        protected override string EmptyCollectionMessage
        {
            get
            {
                return "There are no registered vehicles.";
            }
        }
    }
}

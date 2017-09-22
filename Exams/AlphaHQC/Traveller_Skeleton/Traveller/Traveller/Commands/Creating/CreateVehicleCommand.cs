using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public abstract class CreateVehicleCommand : ICommand
    {
        private readonly ITravellerFactory travellerFactory;
        private readonly IDatabase database;

        public CreateVehicleCommand(ITravellerFactory travellerFactory, IDatabase database)
        {
            Guard.WhenArgument(travellerFactory, "travellerFactory");
            Guard.WhenArgument(database, "database");

            this.travellerFactory = travellerFactory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            IVehicle vehicle = this.CreateVehicle(parameters);
            this.database.Vehicles.Add(vehicle);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }

        protected abstract IVehicle CreateVehicle(IList<string> parameters);

        public ITravellerFactory TravellerFactory
        {
            get
            {
                return this.travellerFactory;
            }
        }
    }
}

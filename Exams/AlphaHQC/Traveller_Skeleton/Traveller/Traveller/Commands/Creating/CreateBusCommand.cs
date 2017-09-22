using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : CreateVehicleCommand, ICommand
    {
        public CreateBusCommand(ITravellerFactory travellerFactory, IDatabase database)
            : base(travellerFactory, database)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.TravellerFactory.CreateBus(passengerCapacity, pricePerKilometer);
            return bus;
        }
    }
}

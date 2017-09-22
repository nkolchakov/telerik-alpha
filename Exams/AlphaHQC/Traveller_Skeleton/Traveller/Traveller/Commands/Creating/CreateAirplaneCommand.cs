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
    public class CreateAirplaneCommand : CreateVehicleCommand, ICommand
    {
        public CreateAirplaneCommand(ITravellerFactory travellerFactory, IDatabase database)
            : base(travellerFactory, database)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = this.TravellerFactory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);

            return airplane;
        }
    }
}

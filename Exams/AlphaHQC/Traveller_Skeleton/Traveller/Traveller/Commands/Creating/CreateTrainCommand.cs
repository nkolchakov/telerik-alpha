using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : CreateVehicleCommand, ICommand
    {
        public CreateTrainCommand(ITravellerFactory travellerFactory, IDatabase database)
            : base(travellerFactory, database)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = this.TravellerFactory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);

            return train;
        }
    }
}

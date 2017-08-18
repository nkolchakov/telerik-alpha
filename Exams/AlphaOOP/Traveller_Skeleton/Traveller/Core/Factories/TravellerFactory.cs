using System;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;
using Traveller.Models.Misc;
using Traveller.Models.Vehicles;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Core.Factories
{
    public class TravellerFactory : ITravellerFactory
    {
        private static ITravellerFactory instanceHolder = new TravellerFactory();

        private TravellerFactory()
        {
        }

        public static ITravellerFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        
        public IBus CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            return new Bus(passengerCapacity, pricePerKilometer);
        }

        public IAirplane CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            return new Airplane(passengerCapacity, pricePerKilometer, hasFreeFood);
        }

        public ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            return new Train(passengerCapacity, pricePerKilometer, carts);
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            return new Journey(startLocation, destination, distance, vehicle);
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            return new Ticket(journey, administrativeCosts);
        }
    }
}

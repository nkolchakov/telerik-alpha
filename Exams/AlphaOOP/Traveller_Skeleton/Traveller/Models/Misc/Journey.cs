using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Misc
{
    public class Journey : IJourney
    {
        private string startLocation;
        private string destination;
        private int distance;

        public Journey(string startingLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startingLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            protected set
            {
                if (value.Length < Constants.StartingLocationMinLength || value.Length > Constants.StartingLocationMaxLength)
                {
                    throw new ArgumentOutOfRangeException($"The StartingLocation's length cannot be less than {Constants.StartingLocationMinLength} or more than {Constants.StartingLocationMaxLength} symbols long.");
                }
                this.startLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            protected set
            {
                if (value.Length < Constants.DestinationMinLength || value.Length > Constants.DestinationMaxLength)
                {
                    throw new ArgumentOutOfRangeException($"The Destination's length cannot be less than {Constants.DestinationMinLength} or more than {Constants.DestinationMaxLength} symbols long.");
                }
                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            protected set
            {
                if (value < Constants.DistanceMinInterval || value > Constants.DistanceMaxInterval)
                {
                    throw new ArgumentOutOfRangeException($"The Distance cannot be less than {Constants.DistanceMinInterval} or more than {Constants.DistanceMaxInterval} kilometers.");
                }
                this.distance = value;
            }
        }

        public IVehicle Vehicle { get; protected set; }

        public decimal CalculateTravelCosts()
        {
            decimal res = this.Distance * this.Vehicle.PricePerKilometer;
            return res;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} ----");
            sb.AppendLine($"Start location: {this.StartLocation}");
            sb.AppendLine($"Destination: {this.Destination}");
            sb.AppendLine($"Distance: {this.Distance}");
            sb.AppendLine($"Vehicle type: {this.Vehicle.Type}");
            sb.AppendLine($"Travel costs: {this.CalculateTravelCosts()}");

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Providers
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.Vehicles = new List<IVehicle>();
            this.Journeys = new List<IJourney>();
            this.Tickets = new List<ITicket>();
            this.TextResult = new StringBuilder();
        }

        public IList<IVehicle> Vehicles { get; }

        public IList<IJourney> Journeys { get; }

        public IList<ITicket> Tickets { get; }

        public StringBuilder TextResult { get; }
    }
}

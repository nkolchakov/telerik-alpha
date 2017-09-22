using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Tests
{
    public static class Helpers
    {
        public static Mock<IDatabase> InitializeDatabaseMock(IList<IVehicle> vehicles = null, IList<IJourney> journeys = null,
           IList<ITicket> tickets = null, StringBuilder textResult = null)
        {
            vehicles = vehicles ?? new List<IVehicle>();
            journeys = journeys ?? new List<IJourney>();
            tickets = tickets ?? new List<ITicket>();
            textResult = textResult ?? new StringBuilder();

            var dbMock = new Mock<IDatabase>();

            dbMock.SetupGet(d => d.Journeys)
                .Returns(journeys);

            dbMock.SetupGet(d => d.TextResult)
                .Returns(textResult);

            dbMock.SetupGet(d => d.Tickets)
                .Returns(tickets);

            dbMock.SetupGet(d => d.Vehicles)
                .Returns(vehicles);

            return dbMock;
        }
    }
}

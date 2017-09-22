using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Contracts;
using System.Collections.Generic;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Core;
using System.Text;
using Traveller.Commands.Creating;
using Traveller.Core.Providers;
using Traveller.Models.Vehicles.Abstractions;
using System.Linq;

namespace Traveller.Tests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShouldCreateTicketThroughFactory_WhenParametersAreValid()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            var firstJourney = new Mock<IJourney>();
            var secondJourney = new Mock<IJourney>();
            var journeysList = new List<IJourney>()
            {
                firstJourney.Object,
                secondJourney.Object
            };

            var databaseMock = Helpers.InitializeDatabaseMock(journeys: journeysList);

            var ticketCommand = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            string journeyId = "1";
            string administrativeCost = "100";
            var parametersList = new List<string>()
            {
                journeyId,
                administrativeCost
            };

            IJourney journeyIdParameter = journeysList[int.Parse(journeyId)];
            decimal administrativeCostParameter = decimal.Parse(administrativeCost);

            // Act
            ticketCommand.Execute(parametersList);

            //Assert
            travellerFactoryMock
                .Verify(t => t.CreateTicket(journeyIdParameter, administrativeCostParameter),
                Times.Once);
        }

        [TestMethod]
        public void ShouldAddTicketToDatabase_WhenParametersAreValid()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            var firstJourney = new Mock<IJourney>();
            var secondJourney = new Mock<IJourney>();
            var journeysList = new List<IJourney>()
            {
                firstJourney.Object,
                secondJourney.Object
            };

            var databaseMock = Helpers.InitializeDatabaseMock(journeys: journeysList);

            string journeyId = "1";
            string administrativeCost = "100";
            var parametersList = new List<string>()
            {
                journeyId,
                administrativeCost
            };

            IJourney journeyIdParameter = journeysList[int.Parse(journeyId)];
            decimal administrativeCostParameter = decimal.Parse(administrativeCost);
            var expectedTicket = new Ticket(journeyIdParameter, administrativeCostParameter);

            travellerFactoryMock.Setup(f => f.CreateTicket(journeyIdParameter, administrativeCostParameter))
                .Returns(expectedTicket);

            var ticketCommand = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Act
            ticketCommand.Execute(parametersList);

            //Assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);
            Assert.AreEqual(expectedTicket, databaseMock.Object.Tickets.Single());
        }

        [TestMethod]
        public void ReturnExecutionResult_WhenParametersAreValid()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            var firstJourney = new Mock<IJourney>();
            var secondJourney = new Mock<IJourney>();
            var journeysList = new List<IJourney>()
            {
                firstJourney.Object,
                secondJourney.Object
            };

            var databaseMock = Helpers.InitializeDatabaseMock(journeys: journeysList);

            string journeyId = "1";
            string administrativeCost = "100";
            var parametersList = new List<string>()
            {
                journeyId,
                administrativeCost
            };

            travellerFactoryMock.Setup(f => f.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()))
                .Returns(It.IsAny<ITicket>());

            var ticketCommand = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            string expectecResult = "Ticket with ID 0 was created.";

            // Act
            var actualResult = ticketCommand.Execute(parametersList);

            //Assert
            Assert.AreEqual(expectecResult, actualResult);
        }

        [TestMethod]
        public void ShouldThrowArgumentException_WhenParamtersAreInvalid()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            var firstJourney = new Mock<IJourney>();
            var secondJourney = new Mock<IJourney>();
            var journeysList = new List<IJourney>()
            {
                firstJourney.Object,
                secondJourney.Object
            };

            var databaseMock = Helpers.InitializeDatabaseMock(journeys: journeysList);

            var ticketCommand = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                    ticketCommand.Execute(new List<string> { "1", null }));
        }

    }
}

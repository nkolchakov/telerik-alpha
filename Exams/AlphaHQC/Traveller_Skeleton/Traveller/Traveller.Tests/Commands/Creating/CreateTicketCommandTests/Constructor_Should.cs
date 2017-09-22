using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveller.Commands.Creating;
using Moq;
using Traveller.Core.Factories;
using Traveller.Core.Contracts;

namespace Traveller.Tests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ShouldReturnInstance_WhenParametersAreValid()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            var databaseMock = Helpers.InitializeDatabaseMock();

            // Act
            var instance = new CreateTicketCommand(travellerFactoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenTravellerFactoryIsNull()
        {
            // Arrange
            var databaseMock = Helpers.InitializeDatabaseMock();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new CreateTicketCommand(null, databaseMock.Object)
            );

        }

        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenDatabaseIsNull()
        {
            // Arrange
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new CreateTicketCommand(travellerFactoryMock.Object, null
            ));

        }
    }
}

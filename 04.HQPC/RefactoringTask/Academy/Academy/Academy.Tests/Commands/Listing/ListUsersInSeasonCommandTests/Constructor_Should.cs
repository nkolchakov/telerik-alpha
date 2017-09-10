using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Academy.Core.Database;
using Academy.Commands.Listing;

namespace Academy.Tests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstace_WhenArgumentsAreValid()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var instance = new ListUsersInSeasonCommand(databaseMock.Object);

            // Act & Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenDatabaseIsNull()
        {
            // AAA
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new ListUsersInSeasonCommand(null);
            });
        }
    }
}
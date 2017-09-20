using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Academy.Core.Database;
using Moq;
using Academy.Commands.Listing;
using System.Collections.Generic;
using Academy.Models.Contracts;
using Academy.Models;
using Academy.Models.Enums;
using System.Text;

namespace Academy.Tests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ListASeasonsWithGivenId_WhenExists()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var listCommand = new ListUsersInSeasonCommand(databaseMock.Object);

            var parametersList = new List<string>() { "0" };
            string expectedResult = "some result";

            var mockedSeason = new Mock<ISeason>();

            mockedSeason.Setup(s => s.ListUsers())
                .Returns(expectedResult);

            var seasonsDatabase = new List<ISeason>()
            {
                mockedSeason.Object
            };

            databaseMock.SetupGet(d => d.Seasons)
                .Returns(seasonsDatabase);

            // Act
            string result = listCommand.Execute(parametersList);

            // Assert
            mockedSeason.Verify(s => s.ListUsers(), Times.Once);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenSeasonIdDoesntExist()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();

            var listCommand = new ListUsersInSeasonCommand(databaseMock.Object);

            var parametersList = new List<string>() { "2" };

            var seasonsDatabase = new List<ISeason>()
            {
                new Mock<ISeason>().Object
            };

            databaseMock.SetupGet(d => d.Seasons)
                .Returns(seasonsDatabase);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                listCommand.Execute(parametersList);
            });
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Traveller.Core.Providers;
using Traveller.Core.Factories;
using Moq;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnParametersList_WhenCommandIsNotNullAndHasParameters()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            string command = "createticket 1 100";
            var expectedResult = new List<string> { "1", "100" };
            var parser = new CommandParser(factoryMock.Object);

            // Act
            var actualResult = parser.ParseParameters(command);

            // Assert
            CollectionAssert.AreEqual(expectedResult, new List<string>(actualResult));
        }

        [TestMethod]
        public void ReturnEmptyList_WhenCommandIsNotNullAndNoParameters()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            string command = "createticket";
            var expectedResult = new List<string>();
            var parser = new CommandParser(factoryMock.Object);

            // Act
            var actualResult = parser.ParseParameters(command);

            // Assert
            CollectionAssert.AreEqual(expectedResult, new List<string>(actualResult));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCommandIsNull()
        {

            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            var parser = new CommandParser(factoryMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => parser.ParseParameters(null));
        }
    }
}

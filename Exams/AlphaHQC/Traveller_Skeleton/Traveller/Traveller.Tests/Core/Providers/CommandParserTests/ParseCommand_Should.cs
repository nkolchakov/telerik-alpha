using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Core;
using Traveller.Core.Factories;
using Traveller.Commands.Contracts;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void ReturnCommandFromFactory_WhenCommandIsNotNull()
        {
            // Arrange
            var commandFactory = new Mock<ICommandFactory>();

            var expectedCommandMock = new Mock<ICommand>();

            commandFactory.Setup(f => f.CreateCommand(It.IsAny<string>()))
                .Returns(expectedCommandMock.Object);

            var parser = new CommandParser(commandFactory.Object);

            // Act
            var actualCommand = parser.ParseCommand("some command");

            // Assert
            Assert.AreEqual(expectedCommandMock.Object, actualCommand);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCommandIsNull()
        {
            // Arrange
            var commandFactory = new Mock<ICommandFactory>();
            var parser = new CommandParser(commandFactory.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            parser.ParseCommand(null));

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveller.Core.Factories;
using Moq;
using Traveller.Core.Providers;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParamtersAreValid()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            // Act
            var instance = new CommandParser(factoryMock.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ThrowArgumenNullException_WhenFactoryIsNull()
        {
            // AAA
            Assert.ThrowsException<ArgumentNullException>(() =>
                new CommandParser(null));
        }
    }
}

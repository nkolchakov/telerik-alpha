using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Academy.Core.Database;
using Academy.Core.Contracts;
using Academy.Commands.Listing;
using Academy.Commands.Creating;

namespace Academy.Tests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenArgumentsAreValid()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();

            // Act 
            var createCourseCommmand = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(createCourseCommmand);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateCourseCommand(null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateCourseCommand(factoryMock.Object, null));
        }
    }
}

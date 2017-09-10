using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Academy.Tests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenArgumentsAreValid()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();

            // Act
            var engine = new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenReaderArgumentIsNull()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();
            
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(null, writerMock.Object, commandProcessorMock.Object, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenWriterArgumentIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();
            
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, null, commandProcessorMock.Object,databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenCommandProcessorArgumentIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var databaseMock = new Mock<IDatabase>();
            
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, writerMock.Object, null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenDatabaseArgumentIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, null));
        }
    }
}

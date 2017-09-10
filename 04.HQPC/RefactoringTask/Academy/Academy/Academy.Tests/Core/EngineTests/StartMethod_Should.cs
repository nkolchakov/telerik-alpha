using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Tests.Core.EngineTests
{
    [TestClass]
    public class StartMethod_Should
    {
        [TestMethod]
        public void CallProcessCommandAndSaveResultToDatabase_WhenCommandIsNonTerminatingAndValid()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();

            var engine = new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, databaseMock.Object);

            string executeResult = "some result";
            string input = "some command";

            readerMock.SetupSequence(r => r.ReadLine())
                .Returns(input)
                .Returns("Exit");

            commandProcessorMock.Setup(p => p.ProcessCommand(input))
                .Returns(executeResult);

            var databaseList = new List<string>();
            databaseMock.SetupGet(d => d.ExecutionResult)
                .Returns(databaseList);

            //Act 
            engine.Start();

            // Assert
            Assert.AreEqual(executeResult, databaseMock.Object.ExecutionResult.Single());
            commandProcessorMock.Verify(p => p.ProcessCommand("some command"), Times.Once);

            // doesn't work, why ?
            // databaseMock.Verify(d => d.ExecutionResult.Contains(executeResult));
        }

        [TestMethod]
        public void ShouldCallWriteMethod_WithTerminatingStringAsAnInput()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();

            var engine = new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, databaseMock.Object);

            var databaseList = new List<string>()
            {
                "first line",
                "second line",
                "test"
            };

            readerMock.SetupSequence(r => r.ReadLine())
                .Returns("Exit");

            databaseMock.SetupGet(d => d.ExecutionResult).Returns(databaseList);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.Write(string.Join("\n", databaseList)),Times.Once);
        }

        [TestMethod]
        public void AddCustomMessageToExecutionResult_WhenArgumentOutOfRangeExceptionIsThrown()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();

            var engine = new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, databaseMock.Object);

            string customErrorMessage = "Invalid command parameters supplied or the entity with that ID for does not exist.";

            readerMock.SetupSequence(r => r.ReadLine())
               .Returns("some command")
               .Returns("Exit");

            // most likely to throw an exception
            commandProcessorMock.Setup(p => p.ProcessCommand("some command"))
                .Throws<ArgumentOutOfRangeException>();

            var databaseList = new List<string>();
            databaseMock.SetupGet(d => d.ExecutionResult)
                .Returns(databaseList);

            // Act
            engine.Start();

            // Assert
            Assert.AreEqual(customErrorMessage, databaseMock.Object.ExecutionResult.Single());
        }

        [TestMethod]
        public void AddErrorMessageToExectionResult_WhenExceptionIsThrown()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var databaseMock = new Mock<IDatabase>();

            var engine = new Engine(readerMock.Object, writerMock.Object, commandProcessorMock.Object, databaseMock.Object);

            string exceptionMessage = new Exception().Message;

            readerMock.SetupSequence(r => r.ReadLine())
               .Returns("some command")
               .Returns("Exit");

            // most likely to throw an exception
            commandProcessorMock.Setup(p => p.ProcessCommand("some command"))
                .Throws<Exception>();

            var databaseList = new List<string>();
            databaseMock.SetupGet(d => d.ExecutionResult)
                .Returns(databaseList);

            // Act
            engine.Start();

            // Assert
            Assert.AreEqual(exceptionMessage, databaseMock.Object.ExecutionResult.Single());
        }
    }
}

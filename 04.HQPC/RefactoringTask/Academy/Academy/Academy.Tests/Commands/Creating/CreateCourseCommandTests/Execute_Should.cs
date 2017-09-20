using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Academy.Models.Contracts;
using Academy.Core.Database;
using Academy.Core.Contracts;
using System.Collections.Generic;
using Academy.Models;
using System.Linq;
using Academy.Commands.Creating;

namespace Academy.Tests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShouldCreateAddCourseToDatabaseAndReturnSuccessMessage_WhenParametersAreValid()
        {
            // Arrange
            var seasonMock = new Mock<ISeason>();
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();

            var seasonId = "0";
            var name = "some course";
            var lecturesPerWeek = "5";
            var startingDate = "2017/03/15";

            var course = new Course(name, int.Parse(lecturesPerWeek), DateTime.Parse(startingDate), DateTime.Parse(startingDate).AddDays(30));

            var databaseSeasons = new List<ISeason>() { seasonMock.Object };
            var seasonCourses = new List<ICourse>();
            var parametersList = new List<string>()
            {
                seasonId,name,lecturesPerWeek,startingDate
            };

            seasonMock.SetupGet(s => s.Courses)
                .Returns(seasonCourses);

            databaseMock.SetupGet(d => d.Seasons)
                .Returns(databaseSeasons);
            
            factoryMock.Setup(f => f.CreateCourse(name, lecturesPerWeek, startingDate))
                .Returns(course);

            var createCourseCommand = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            string expectedsuccessMessage = "Course with ID 0 was created in Season 0.";

            // Act
            string successMessage = createCourseCommand.Execute(parametersList);

            // Assert
            Assert.AreEqual(course, seasonMock.Object.Courses.Single());
            Assert.AreEqual(expectedsuccessMessage, successMessage);
        }
        
        // one more unit test only for successful message

        [TestMethod]
        public void ShouldThrowArgumentOutOfRangeException_WhenParametersListIsNotFull()
        {
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();

            var parametersList = new List<string>()
            {
                "just name"
            };

            var createCourseCommand = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => createCourseCommand.Execute(parametersList));
        }
    }
}

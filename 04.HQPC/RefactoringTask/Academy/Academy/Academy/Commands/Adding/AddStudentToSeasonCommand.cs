using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddStudentToSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase database;

        public AddStudentToSeasonCommand(IAcademyFactory factory, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var studentUsername = parameters[0];
            var seasonId = parameters[1];

            var student = this.database.Students.Single(x => x.Username.ToLower() == studentUsername.ToLower());
            var season = this.database.Seasons[int.Parse(seasonId)];

            if (season.Students.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The Student {studentUsername} is already a part of Season {seasonId}!");
            }

            season.Students.Add(student);
            return $"Student {studentUsername} was added to Season {seasonId}.";
        }
    }
}

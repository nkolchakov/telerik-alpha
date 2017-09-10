using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Database;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase database;

        public CreateSeasonCommand(IAcademyFactory factory, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var startingYear = parameters[0];
            var endingYear = parameters[1];
            var initiative = parameters[2];

            var season = this.factory.CreateSeason(startingYear, endingYear, initiative);
            this.database.Seasons.Add(season);

            return $"Season with ID {this.database.Seasons.Count - 1} was created.";
        }
    }
}

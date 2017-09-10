using Academy.Commands.Contracts;
using Academy.Core.Database;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IDatabase database;

        public ListUsersInSeasonCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.database.Seasons[int.Parse(seasonId)];

            return season.ListUsers();
        }
    }
}

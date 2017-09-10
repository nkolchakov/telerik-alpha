using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IDatabase database;

        public ListUsersCommand(IDatabase database)
        {
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var trainers = this.database.Trainers;
            var students = this.database.Students;

            if (trainers.Any())
            {
                foreach (var trainer in trainers)
                {
                    builder.AppendLine(trainer.ToString());
                }
            }

            if (students.Any())
            {
                foreach (var student in students)
                {
                    builder.AppendLine(student.ToString());
                }
            }

            if (builder.ToString().Equals(""))
            {
                return "There are no registered users!";
            }

            return builder.ToString().TrimEnd();
        }
    }
}

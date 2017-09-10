using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase database;

        public CreateStudentCommand(IAcademyFactory factory, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var track = parameters[1];

            if (this.database.Students.Any(x => x.Username.ToLower() == username.ToLower()) ||
                this.database.Trainers.Any(x => x.Username.ToLower() == username.ToLower()))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var student = this.factory.CreateStudent(username, track);
            this.database.Students.Add(student);

            return $"Student with ID {this.database.Students.Count - 1} was created.";
        }
    }
}

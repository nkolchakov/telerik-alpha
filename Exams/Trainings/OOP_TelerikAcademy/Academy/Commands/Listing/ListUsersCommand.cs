using System;
using System.Collections.Generic;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        // TODO: Implement this
        public string Execute(IList<string> parameters)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var trainer in engine.Trainers)
            {
                sb.AppendLine(trainer.ToString());
            }
            foreach (var student in engine.Students)
            {
                sb.AppendLine(student.ToString());
            }
            return sb.Length > 0 ? sb.ToString().TrimEnd() : "There are no registered users!";
        }
    }
}

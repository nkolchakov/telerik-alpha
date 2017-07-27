using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using System.Text;
using System.Linq;
using OlympicGames.Olympics.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : Command
    {
        // Consider using the dictionary
        private readonly IDictionary<string, double> records;

        public CreateSprinterCommand(IList<string> commandLine)
            : base(commandLine)
        {
            this.records = new Dictionary<string, double>();
        }

        public override string Execute()
        {
            var parameters = this.CommandParameters;

            if (parameters.Count < Constants.SprinterMinParamsCount)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            string firstName = parameters[0];
            string lastName = parameters[1];
            string country = parameters[2];

            // ["100/19.5", "200/25.3"]
            var recordsAsArr = parameters.Skip(Constants.SprinterMinParamsCount).ToArray();
            foreach (string record in recordsAsArr)
            {
                var splitted = record.Split('/');
                string track = splitted[0];
                double time = double.Parse(splitted[1]);
                this.records[track] = time;
            }

            IOlympian sprinter = this.Factory.CreateSprinter(firstName, lastName, country, this.records);
            this.Committee.Olympians.Add(sprinter);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Constants.CreatedSprinterText);
            sb.AppendLine(sprinter.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Factories;
using System.Text;
using OlympicGames.Olympics.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command
    {
        public CreateBoxerCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            var parameters = this.CommandParameters;

            if (parameters.Count != Constants.BoxersParamsCount)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            string firstName = parameters[0];
            string lastName = parameters[1];
            string country = parameters[2];
            string category = parameters[3];

            int wins;
            bool parsedWin = int.TryParse(parameters[4], out wins);
            int loses;
            bool parsedLose = int.TryParse(parameters[5], out loses);

            if (!parsedWin || !parsedLose)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }

            IOlympian boxer = this.Factory.CreateBoxer(firstName, lastName, country, category, wins, loses);
            this.Committee.Olympians.Add(boxer);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Constants.CreatedBoxerText);
            sb.AppendLine(boxer.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}

using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Olympics.Models.Abstracts;
using OlympicGames.Olympics.Utils;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Olympics.Models
{
    public class Boxer : Olympian, IBoxer
    {
        private int wins;
        private int loses;

        public Boxer(string firstName, string lastName, string country,
            BoxingCategory category, int wins, int loses)
            : base(firstName, lastName, country)
        {
            this.Category = category;
            this.Wins = wins;
            this.Losses = loses;
        }

        public BoxingCategory Category { get; private set; }

        public int Wins
        {
            get
            {
                return this.wins;
            }
            set
            {
                Validator.ValidateMinAndMaxNumber(value, Constants.MinWins, Constants.MaxWins,
                    string.Format(Constants.WinsRangeInvalid, Constants.MinWins, Constants.MaxWins));
                this.wins = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.loses;
            }
            set
            {
                Validator.ValidateMinAndMaxNumber(value, Constants.MinLosses, Constants.MaxLosses,
                    string.Format(Constants.LossesRangeInvalid, Constants.MinLosses, Constants.MaxLosses));

                this.loses = value;
            }
        }

        protected override string Type
        {
            get
            {
                return Constants.BoxerType;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Category: {this.Category}");
            sb.AppendLine($"Wins: {this.Wins}");
            sb.AppendLine($"Losses: {this.Losses}");

            return sb.ToString().TrimEnd();
        }
    }
}

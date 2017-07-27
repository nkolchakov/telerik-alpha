using OlympicGames.Olympics.Contracts;
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
    public class Sprinter : Olympian, ISprinter
    {
        public Sprinter(string firstName, string lastName, string country, 
            IDictionary<string, double> personalRecords)
            : base(firstName, lastName, country)
        {
            this.PersonalRecords = personalRecords;
        }

        public IDictionary<string, double> PersonalRecords { get; private set; }

        protected override string Type
        {
            get
            {
                return Constants.SprinterType;
            }
        }

        public override string ToString()
        {
            if (this.PersonalRecords.Count() == 0)
            {
                return base.ToString() + GlobalConstants.NoPersonalRecordsSet;
            }

            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine(GlobalConstants.PersonalRecords);
            foreach (var kvPair in this.PersonalRecords)
            {
                sb.AppendLine($"{kvPair.Key}m: {kvPair.Value}s");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

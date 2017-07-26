using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Trainer : ITrainer
    {
        private string username;

        public Trainer(string username, string commaSeparatedTechnologies)
        {
            this.Username = username;
            this.Technologies = new List<string>(commaSeparatedTechnologies.Split(','));
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                }
                this.username = value;
            }
        }

        public IList<string> Technologies { get; set; }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("* Trainer:");
            res.AppendLine(" - Username: " + this.Username);
            res.Append(" - Technologies: " + string.Join("; ", this.Technologies));

            return res.ToString();
        }
    }
}

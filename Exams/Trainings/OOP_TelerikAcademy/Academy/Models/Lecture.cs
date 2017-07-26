using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;
        private ITrainer trainer;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateParser.Parse(date);
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }
        public DateTime Date { get; set; }

        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Trainer cannot be null!");
                }
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources
        {
            get;
            private set;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("  * Lecture:");
            res.AppendLine("   - Name: " + this.Name);
            res.AppendLine("   - Date: " + this.Date);
            res.AppendLine("   - Trainer username: " + this.trainer.Username);
            res.AppendLine("   - Resources:");
            res.Append(this.Resources.Count > 0 ? string.Join("\n", this.Resources) : "    * There are no resources in this lecture.");

            return res.ToString();
        }
    }
}

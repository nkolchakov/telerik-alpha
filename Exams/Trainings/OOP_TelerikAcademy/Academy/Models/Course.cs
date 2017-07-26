using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);

            this.StartingDate = DateParser.Parse(startingDate);
            this.EndingDate = this.StartingDate.AddDays(30);

            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeek = value;
            }
        }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public IList<IStudent> OnsiteStudents { get; private set; }

        public IList<IStudent> OnlineStudents { get; private set; }

        public IList<ILecture> Lectures { get; private set; }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("* Course:");
            res.AppendLine(" - Name: " + this.Name);
            res.AppendLine(" - Lectures per week: " + this.LecturesPerWeek);
            res.AppendLine(" - Starting date: " + this.StartingDate);
            res.AppendLine(" - Ending date: " + this.EndingDate);
            res.AppendLine(" - Onsite students: " + this.OnsiteStudents.Count);
            res.AppendLine(" - Online students: " + this.OnlineStudents.Count);
            res.AppendLine(" - Lectures:");
            res.Append(this.Lectures.Count > 0 ? string.Join("\n", this.Lectures) : "  * There are no lectures in this course!");

            return res.ToString();
        }
    }
}

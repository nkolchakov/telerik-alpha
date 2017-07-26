using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class Student : IStudent
    {
        private string username;

        public Student(string username, string track)
        {
            this.Username = username;
            Track parsed;
            if (!Enum.TryParse(track, out parsed))
            {
                throw new ArgumentException("The provided track is not valid!");
            }
            this.Track = parsed;
            this.CourseResults = new List<ICourseResult>();
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

        public Track Track { get; set; }
        public IList<ICourseResult> CourseResults { get; set; }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("* Student:");
            res.AppendLine(" - Username: " + this.Username);
            res.AppendLine(" - Track: " + this.Track);
            res.AppendLine(" - Course results:");
            res.Append(this.CourseResults.Count > 0 ? string.Join("\n", this.CourseResults) : "  * User has no course results!");

            return res.ToString();
        }
    }
}

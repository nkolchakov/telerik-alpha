using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public abstract class LectureResource : ILectureResource
    {
        private string name;
        private string url;

        public LectureResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        }
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        }

        // Damn ... that's beautiful
        public abstract ResourceType Type { get; }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine("    * Resource:");
            res.AppendLine("     - Name: " + this.Name);
            res.AppendLine("     - Url: " + this.Url);
            res.Append("     - Type: " + this.Type);

            return res.ToString();
        }
    }
}

using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class HomeworkResource : LectureResource
    {
        public HomeworkResource(string name, string url, DateTime dueDate)
            : base(name, url)
        {
            this.DueDate = dueDate;
        }

        public DateTime DueDate { get; private set; }

        public override ResourceType Type
        {
            get
            {
                return ResourceType.Homework;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\n     - Due date: {this.DueDate}";
        }
    }
}

using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class DemoResource : LectureResource
    {
        public DemoResource(string name, string url)
            : base(name, url)
        {
        }

        public override ResourceType Type
        {
            get
            {
                return ResourceType.Demo;
            }
        }
    }
}

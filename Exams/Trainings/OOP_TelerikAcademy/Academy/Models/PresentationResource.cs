using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class PresentationResource : LectureResource
    {
        public PresentationResource(string name, string url)
            : base(name, url)
        {
        }

        public override ResourceType Type
        {
            get
            {
                return ResourceType.Presentation;
            }
        }
    }
}

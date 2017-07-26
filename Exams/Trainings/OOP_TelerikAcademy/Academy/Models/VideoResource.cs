using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class VideoResource : LectureResource
    {
        public VideoResource(string name, string url, DateTime uploadedOn)
            : base(name, url)
        {
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn { get; set; }

        public override ResourceType Type
        {
            get
            {
                return ResourceType.Video;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\n     - Uploaded on: {this.UploadedOn}";
        }
    }
}

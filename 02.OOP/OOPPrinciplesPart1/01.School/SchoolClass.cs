using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class SchoolClass
    {
        private ISet<Teacher> teachers;

        // TODO: dependency ?
        private string textId = Guid.NewGuid().ToString();

        public SchoolClass()
        {
            this.Teachers = new HashSet<Teacher>();
        }

        public SchoolClass(ISet<Teacher> teachersSet)
        {
            this.Teachers = teachersSet;
        }

        public string TextId
        {
            get
            {
                return this.textId;
            }
        }

        public ISet<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teachers collection cannot be null");
                }
                this.teachers = value;
            }
        }
    }
}

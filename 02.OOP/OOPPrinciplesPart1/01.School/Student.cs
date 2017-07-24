using _01.School.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Student : Person, IComment
    {
        private static int studentIdGenerator = 1000;
        private int uniqueId = studentIdGenerator++;

        private ICollection<string> comments;

        public Student(string name, IEnumerable<string> comments = null)
            : base(name)
        {
            if (comments != null)
            {
                this.comments = new List<string>(comments);
            }
            else
            {
                this.comments = new List<string>();
            }
        }

        public int UniqueId
        {
            get
            {
                return this.uniqueId;
            }
        }

        // TODO: code repetition for every class with comments ?
        public ICollection<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void AddComment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Comment cannot be null or empty");
            }
            this.comments.Add(text);
        }
    }
}

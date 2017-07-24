using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School.Contracts
{
    public interface IComment
    {
        ICollection<string> Comments { get; }

        void AddComment(string text);
    }
}

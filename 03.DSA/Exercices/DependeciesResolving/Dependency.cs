using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependeciesResolving
{
    public class Dependency
    {
        public string ProjectName { get; set; }
        public IEnumerable<string> Dependencies { get; set; }
    }
}

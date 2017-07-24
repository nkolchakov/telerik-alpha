using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    public abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // validation .. I know
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

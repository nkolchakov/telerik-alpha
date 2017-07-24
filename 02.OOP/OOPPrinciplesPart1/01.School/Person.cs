using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    // TODO : when its ok to have abstract class only for ctor ?
    public abstract class Person
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                this.name = value;
            }
        }
    }
}

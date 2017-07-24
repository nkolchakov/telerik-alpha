using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.AnimalHierarchy.Enums;

namespace _03.AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name)
            : base(age, name, Gender.Female)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm Kitten");
        }
    }
}

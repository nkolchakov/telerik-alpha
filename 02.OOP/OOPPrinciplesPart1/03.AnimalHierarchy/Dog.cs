using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.AnimalHierarchy.Enums;

namespace _03.AnimalHierarchy
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Gender gender)
            : base(age, name, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm dog");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.AnimalHierarchy.Enums;

namespace _03.AnimalHierarchy
{
    public class Cat : Animal
    {
        public Cat(int age, string name, Gender gender)
            : base(age, name, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Im generic Cat");
        }
    }
}

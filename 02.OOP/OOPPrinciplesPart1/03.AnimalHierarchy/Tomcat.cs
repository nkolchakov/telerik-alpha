using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.AnimalHierarchy.Enums;

namespace _03.AnimalHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, Gender.Male)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm Tomcat -> Maxi");
        }
    }
}

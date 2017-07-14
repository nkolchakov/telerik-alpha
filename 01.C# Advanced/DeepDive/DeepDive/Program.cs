using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDive
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "asd";
            Console.WriteLine(s);
            ChangeName(s);
            Console.WriteLine(s);
        }

        static void ChangeName(string s)
        {
            s = "aaa";
        }
    }
    class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

}

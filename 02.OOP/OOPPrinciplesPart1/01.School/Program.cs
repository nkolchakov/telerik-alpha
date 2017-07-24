using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new SchoolClass();
            var class2 = new SchoolClass();
            var class3 = new SchoolClass();

            var student1 = new Student("asd");
            var student2 = new Student("aggd");
            var student3 = new Student("vxvxv");


            Console.WriteLine(class1.TextId);
            Console.WriteLine(class2.TextId);
            Console.WriteLine(class3.TextId);

            Console.WriteLine(student1.UniqueId);
            Console.WriteLine(student2.UniqueId);
            Console.WriteLine(student3.UniqueId);
        }
    }
}

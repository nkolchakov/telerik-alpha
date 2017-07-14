using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EnglishDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> mapping = new Dictionary<int, string>()
            {
                {0, "zero" },
                {1, "one" },
                {2, "two" },
                {3, "three" },
                {4, "four" },
                {5, "five" },
                {6, "six" },
                {7, "seven" },
                {8, "eight" },
                {9, "nine" }
            };

            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(mapping[number % 10]);
        }
    }
}

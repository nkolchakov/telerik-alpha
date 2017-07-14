using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GetMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int first = numbers[0];
            int second = numbers[1];
            int third = numbers[2];

            int max = GetMax(first, second, third);
            Console.WriteLine(max);
        }

        public static int GetMax(int a, int b, int c)
        {
            if (a > b)
            {
                if (a > c)
                {
                    return a;
                }else
                {
                    return c;
                }
            }
            else
            {
                if(b > c)
                {
                    return b;
                }
                else
                {
                    return c;
                }
            }
        }
    }
}

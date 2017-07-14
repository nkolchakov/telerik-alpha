using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(1);

            int start = 1;
            int input = 1;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    input = ReadNumber(start, input);
                    start = input;
                    list.Add(input);
                }
                catch
                {
                    Console.WriteLine("Exception");
                    return;
                }
            }
            if (list.Last() < 100)
            {
                list.Add(100);
            }
            else
            {
                Console.WriteLine("Exception");
                return;
            }

            Console.WriteLine(string.Join(" < ", list));
        }

        private static int ReadNumber(int start, int end)
        {
            int input = int.Parse(Console.ReadLine());
            end = input + 1;
            if (input <= start || input >= end)
            {
                throw new Exception();
            }
            return input;

        }

    }
}

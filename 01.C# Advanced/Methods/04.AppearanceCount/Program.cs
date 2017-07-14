using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AppearanceCount
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string elements = Console.ReadLine();
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(MaxAppearance(elements, target));
        }

        static int MaxAppearance(string els, int target)
        {
            int count = 0;
            var parsed = els.Split(' ').Select(x => int.Parse(x)).ToArray();
            foreach (var item in parsed)
            {
                if(item == target)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

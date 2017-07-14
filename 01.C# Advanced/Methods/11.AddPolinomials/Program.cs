using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AddPolynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] second = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                res[i] = first[i] + second[i];
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
}

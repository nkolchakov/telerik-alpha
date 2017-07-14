using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int res = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (BiggerThanNeighbours(arr, i))
                {
                    res++;
                }
            }

            Console.WriteLine(res);
        }

        private static bool BiggerThanNeighbours(int[] arr, int i)
        {
            return arr[i] > arr[i - 1] && arr[i] > arr[i + 1];
        }
    }
}

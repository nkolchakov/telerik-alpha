using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FirstLargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (BiggerThanNeighbours(arr, i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }

        }

        private static bool BiggerThanNeighbours(int[] arr, int i)
        {
            return arr[i] > arr[i - 1] && arr[i] > arr[i + 1];
        }
    }
}

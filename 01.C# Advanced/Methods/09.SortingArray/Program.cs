using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SortingArray
{
    class Program
    {
        /*
6
3 4 1 5 2 6
         */

        /*
10
36 10 1 34 28 38 31 27 30 20
         */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int[] sorted = Sort(arr,false);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] Sort(int[] arr, bool ascending = true)
        {

            int[] sorted = (int[])arr.Clone();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int maxIndex = FindMax(sorted, i);
                Swap(ref sorted, i, maxIndex);
            }
            if (ascending)
            {
                Reverse(sorted);
            }
            return sorted;
        }

        private static void Reverse(int[] sorted)
        {
            for (int i = 0; i < sorted.Length / 2; i++)
            {
                Swap(ref sorted, i, sorted.Length - 1 - i);
            }
        }

        private static void Swap(ref int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        private static int FindMax(int[] arr, int from)
        {
            int max = arr[from];
            int index = from;
            for (int i = from + 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }

            return index;
        }
    }
}

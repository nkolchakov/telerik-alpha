using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            //GenerateWithDuplicates(n, k);
            GenerateWithoutDuplicates(n, k);
        }

        private static void GenerateWithDuplicates(int n, int k)
        {
            var nums = new int[k];
            GenerateNestedLoopWithDUplicates(1, 0, n, nums);
        }

        static void GenerateWithoutDuplicates(int n, int k)
        {
            var nums = new int[k];
            var used = new bool[n + 1];
            GenerateNestedLoopWithtouDuplicates(1, 0, n, nums, used);
        }

        private static void GenerateNestedLoopWithtouDuplicates(int start, int index, int n, int[] arr, bool[] used)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int value = start; value <= n; value++)
            {
                if (!used[value])
                {
                    arr[index] = value;
                    used[value] = true;
                    GenerateNestedLoopWithtouDuplicates(value, index + 1, n, arr, used);
                    used[value] = false;
                }
            }
        }

        private static void GenerateNestedLoopWithDUplicates(int start, int index, int n, int[] arr)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int value = start; value <= n; value++)
            {
                arr[index] = value;
                GenerateNestedLoopWithDUplicates(value, index + 1, n, arr);
            }
        }
    }
}

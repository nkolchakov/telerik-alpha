using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Generate(n);
        }
        static void Generate(int n)
        {
            var nums = new int[n];
            var used = new bool[n + 1];
            GenerateNestedLoop(0, nums, used);
        }

        private static void GenerateNestedLoop(int index, int[] arr, bool[] used)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int value = 1; value <= arr.Length; value++)
            {
                if (!used[value])
                {
                    arr[index] = value;
                    used[value] = true;
                    GenerateNestedLoop(index + 1, arr, used);
                    used[value] = false;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 5, 7, 9, 11, 20, 55, 103, 350, 1100, 2050 };

            Console.WriteLine(BinarySearch(arr, int.Parse(Console.ReadLine())));
        }
        public static int BinarySearch(int[] arr, int value)
        {
            return BinarySearchRec(arr, 0, arr.Length - 1, value);
        }

        public static int BinarySearchRec(int[] arr, int min, int max, int value)
        {
            if (min > max)
            {
                return -1;
            }

            int mid = (max + min) / 2;
            if (arr[mid] == value)
            {
                return mid;
            }

            if (value > arr[mid])
            {
                return BinarySearchRec(arr, mid + 1, max, value);
            }
            else
            {
                return BinarySearchRec(arr, min, mid - 1, value);
            }
        }
    }
}

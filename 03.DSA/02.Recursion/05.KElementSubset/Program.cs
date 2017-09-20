using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.KElementSubset
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            string[] set = new string[] { "hi", "a", "b" };

            string[] variation = new string[k];
            Generate(0, set, variation);
        }

        private static void Generate(int index, string[] set, string[] variation)
        {
            if (index >= variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                variation[index] = set[i];
                Generate(index + 1, set, variation);
            }

        }
    }
}

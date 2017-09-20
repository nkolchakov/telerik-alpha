using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SubsetOfKStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] set = new string[] { "test", "rock", "fun" };
            int k = 3;

            Generate(k, set);
        }

        private static void Generate(int k, string[] set)
        {
            bool[] used = new bool[set.Length];
            string[] subset = new string[k];
            SubsetOfKStrings(0, 0, set, subset, k, used);
        }

        private static void SubsetOfKStrings(int start, int index, string[] set, string[] subset, int k, bool[] used)
        {
            if (index >= subset.Length)
            {
                Console.WriteLine(string.Join(" ", subset));
                return;
            }

            for (int i = start; i < set.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    subset[index] = set[i];
                    SubsetOfKStrings(i, index + 1, set, subset, k, used);
                    used[i] = false;
                }
            }
        }
    }
}

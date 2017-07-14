using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
3 4
8 3 3
6 2 4 2

5 5
0 3 9 3 2
5 9 5 1 7
 */
namespace _08.NumberAsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine();

            var first = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var second = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

           

            var res = Calculate(first, second);
            Console.WriteLine(string.Join(" ", res));

        }

        private static void MakeSameSizes(ref int[] first, ref int[] second)
        {
            if (first.Length == second.Length)
            {
                return;
            }
            int firstLen = first.Length;
            int secLen = second.Length;
            if (firstLen > secLen)
            {
                int[] newArr = new int[firstLen];
                for (int i = 0; i < firstLen; i++)
                {
                    if (i < secLen)
                    {
                        newArr[i] = second[i];
                    }
                }
                second = newArr;
            }
            else
            {
                int[] newArr = new int[secLen];
                for (int i = 0; i < secLen; i++)
                {
                    if (i < firstLen)
                    {
                        newArr[i] = first[i];
                    }
                }
                first = newArr;
            }
        }

        private static int[] Calculate(int[] first, int[] second)
        {
            MakeSameSizes(ref first, ref second);

            int len = first.Length;
            int[] res = new int[len];

            bool hasRemaining = false;
            for (int i = 0; i < len; i++)
            {
                int toAdd = first[i] + second[i];
                if (hasRemaining)
                {
                    toAdd++;
                }

                res[i] = toAdd % 10;
                hasRemaining = toAdd >= 10;
            }
            return res;
        }
    }
}

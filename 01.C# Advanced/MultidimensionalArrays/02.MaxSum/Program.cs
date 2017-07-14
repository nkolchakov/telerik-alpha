using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaxSum
{
    class Program
    {
/*
5 5
1 1 3 3 5
-6 -7 2 -3 -1
3 0 -4 5 9
7 -7 0 1 0
-7 -6 -4 -4 9
*/
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(' ');
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);

            int[,] mtx = new int[n, m];

            for (int i = 0; i < mtx.GetLength(0); i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    mtx[i, j] = int.Parse(line[j]);
                }
            }

            int currSum = int.MinValue;
            int maxSum = currSum;
            for (int r = 0; r < mtx.GetLength(0); r++)
            {
                for (int c = 0; c < mtx.GetLength(1); c++)
                {
                    if (CanFit(mtx, r, c))
                    {
                        currSum = SumSubmatrix(mtx, r, c);
                        if (currSum > maxSum)
                        {
                            maxSum = currSum;
                        }
                    }
                }
            }

            Console.WriteLine(maxSum);

        }

        static int SumSubmatrix(int[,] mtx, int r, int c)
        {

            int sum = 0;
            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    sum += mtx[i, j];
                }
            }

            return sum;
        }

        static bool CanFit(int[,] mtx, int r, int c)
        {
            int m = mtx.GetLength(0);
            int n = mtx.GetLength(1);
            return r + 2 < m && c + 2 < n;
        }

        static void PrintMtx(int[,] mtx)
        {
            for (int row = 0; row < mtx.GetLength(0); row++)
            {
                StringBuilder sb = new StringBuilder();
                for (int col = 0; col < mtx.GetLength(1); col++)
                {
                    sb.Append(mtx[row, col] + " ");
                }
                Console.WriteLine(sb.ToString().Trim());

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
6 6
92 11 23 42 59 48
09 92 23 72 48 14
17 63 92 48 85 95
34 17 48 69 23 23
26 48 17 71 29 95
17 34 16 17 39 95
 
 */


namespace _03.Sequence
{
    class Program
    {
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
            List<int> res = new List<int>();

            res.Add(CheckHorizontal(mtx));
            res.Add(CheckVertical(mtx));
            res.Add(CheckEveryDiagonal(mtx));
            res.Add(CheckEverySecondaryDiagonal(mtx));
            Console.WriteLine(res.Max() + 1);
        }

        private static int CheckEverySecondaryDiagonal(int[,] mtx)
        {
            List<int> res = new List<int>();

            // right side first
            for (int r = mtx.GetLength(0) - 1, c = mtx.GetLength(1) - 1; r >= 0; r--)
            {
                res.Add(CheckSecondaryDiagonalFromElement(mtx, r, c));
            }

            // top side 
            for (int c = mtx.GetLength(1) - 1, r = 0; c >= 0; c--)
            {
                res.Add(CheckSecondaryDiagonalFromElement(mtx, r, c));
            }

            return res.Max();
        }

        private static int CheckSecondaryDiagonalFromElement(int[,] mtx, int r, int c)
        {
            int currSeq = 0;
            int max = currSeq;

            while (r < mtx.GetLength(0) - 1 && c - 1 > 0)
            {
                if (mtx[r, c] == mtx[r + 1, c - 1])
                {
                    currSeq++;
                    if (currSeq > max) max = currSeq;
                }
                else currSeq = 0;
                r++;
                c--;
            }
            return max;
        }

        // check diagonals from each element from the side
        private static int CheckEveryDiagonal(int[,] mtx)
        {
            List<int> res = new List<int>();

            // left side first
            for (int r = mtx.GetLength(0) - 1, c = 0; r >= 0; r--)
            {
                res.Add(CheckDiagonalFromElement(mtx, r, c));
            }

            // top side 
            for (int c = 0, r = 0; c < mtx.GetLength(1); c++)
            {
                res.Add(CheckDiagonalFromElement(mtx, r, c));
            }

            return res.Max();
        }

        private static int CheckDiagonalFromElement(int[,] mtx, int r, int c)
        {
            int currSeq = 0;
            int max = currSeq;

            while ((r < mtx.GetLength(0) - 1) && (c < mtx.GetLength(1) - 1))
            {
                if (mtx[r, c] == mtx[r + 1, c + 1])
                {
                    currSeq++;
                    if (currSeq > max) max = currSeq;
                }
                else currSeq = 0;
                r++;
                c++;
            }
            return max;
        }

        private static int CheckVertical(int[,] mtx)
        {
            int currSeq = 0;
            int max = currSeq;

            for (int c = 0; c < mtx.GetLength(1); c++)
            {
                for (int r = 0; r < mtx.GetLength(0) - 1; r++)
                {
                    if (mtx[r, c] == mtx[r + 1, c])
                    {
                        currSeq++;
                        if (currSeq > max) max = currSeq;
                    }
                    else currSeq = 0;
                }
            }
            return max;
        }

        private static int CheckHorizontal(int[,] mtx)
        {
            int currSeq = 0;
            int max = currSeq;

            for (int r = 0; r < mtx.GetLength(0); r++)
            {
                for (int c = 0; c < mtx.GetLength(1) - 1; c++)
                {
                    if (mtx[r, c] == mtx[r, c + 1])
                    {
                        currSeq++;
                        if (currSeq > max) max = currSeq;
                    }
                    else currSeq = 0;
                }
            }
            return max;
        }
    }
}

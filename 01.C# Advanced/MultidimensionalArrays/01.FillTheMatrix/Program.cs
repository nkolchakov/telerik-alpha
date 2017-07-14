using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillTheMatrix
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string mode = Console.ReadLine();
            int[,] mtx = new int[n, n];

            switch (mode)
            {
                case "a":
                    FillA(mtx);
                    break;
                case "b":
                    FillB(mtx);
                    break;
                case "c":
                    FillC(mtx);
                    break;
                case "d":
                    FillD(mtx);
                    break;
                default:
                    break;
            }

            PrintMtx(mtx);
        }

        static void FillD(int[,] mtx)
        {
            int n = mtx.GetLength(0);
            string direction = "down";
            int value = 1;
            int row = 0;
            int col = 0;
            mtx[row, col] = value++;

            while (value <= n * n)
            {
                if (direction == "left")
                {
                    if (NextPositionAvaialbe(mtx, row, col - 1))
                    {
                        col--;
                        mtx[row, col] = value++;
                    }
                    else
                    {
                        direction = "down";
                    }
                }

                if (direction == "down")
                {
                    if (NextPositionAvaialbe(mtx, row + 1, col))
                    {
                        row++;
                        mtx[row, col] = value++;
                    }
                    else
                    {
                        direction = "right";
                    }
                }
                if (direction == "right")
                {
                    if (NextPositionAvaialbe(mtx, row, col + 1))
                    {
                        col++;
                        mtx[row, col] = value++;
                    }
                    else
                    {
                        direction = "top";
                    }
                }
                if (direction == "top")
                {
                    if (NextPositionAvaialbe(mtx, row - 1, col))
                    {
                        row--;
                        mtx[row, col] = value++;
                    }
                    else
                    {
                        direction = "left";
                    }
                }
            }

        }

        private static bool NextPositionAvaialbe(int[,] mtx, int row, int col)
        {
            return row >= 0 && mtx.GetLongLength(0) > row &&
                col >= 0 && mtx.GetLength(1) > col &&
                mtx[row, col] == 0;
        }

        static bool ExistsCoord(int[,] mtx, int r, int c)
        {
            int n = mtx.GetLength(0);
            return r >= 0 && r < n && c >= 0 && c < n;
        }

        static void FillC(int[,] mtx)
        {
            int value = 1;
            int startRow = mtx.GetLength(0) - 1;
            int startCol = 0;

            while (true)
            {
                int row = startRow;
                int col = startCol;

                // check before incrementation in the loop
                bool isCorner = false;
                while (ExistsCoord(mtx, row, col))
                {
                    mtx[row, col] = value++;
                    isCorner = IsCorner(mtx, row, col);
                    row++;
                    col++;

                }
                if (isCorner)
                {
                    break;
                }
                if (startRow > 0)
                {
                    startRow--;
                }
                else
                {
                    startCol++;
                }
            }
        }

        static bool IsCorner(int[,] mtx, int r, int c)
        {
            if (ExistsCoord(mtx, r, c))
            {
                return !ExistsCoord(mtx, r - 1, c) && !ExistsCoord(mtx, r, c + 1);
            }
            return false;
        }

        static void FillB(int[,] mtx)
        {
            int n = mtx.GetLength(0);
            int evenValue = 1;
            int oddValue = evenValue + n;

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        mtx[j, i] = evenValue++;
                    }
                    evenValue += n;
                }
                else
                {
                    for (int k = n - 1; k >= 0; k--)
                    {
                        mtx[k, i] = oddValue++;
                    }
                    oddValue += n;
                }
            }
        }

        static void FillA(int[,] mtx)
        {
            int value = 1;
            for (int rows = 0; rows < mtx.GetLength(0); rows++)
            {
                for (int cols = 0; cols < mtx.GetLength(1); cols++)
                {
                    mtx[cols, rows] = value++;
                }
            }
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

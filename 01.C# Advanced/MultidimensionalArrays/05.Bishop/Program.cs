using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bishop
{
    class Program
    {
        /**
6 7
5
UR 5
RD 2
DL 3
LU 6
DR 5
         */
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            int[,] mtx = new int[rows, cols];
            FillDiagonals(mtx, 0);

            int turns = int.Parse(Console.ReadLine());

            //PrintMatrix(mtx);
            List<int> score = new List<int>();

            int row = mtx.GetLength(0) - 1;
            int col = 0;

            for (int i = 0; i < turns; i++)
            {
                var commands = Console.ReadLine().Split(' ');
                string direction = commands[0];
                int moves = int.Parse(commands[1]);

                var scoresToAdd = GetScore(mtx, direction, moves, ref row, ref col);
                score.AddRange(scoresToAdd);
            }

            Console.WriteLine(score.Sum());
            //Console.Read();
        }

        private static IEnumerable<int> GetScore(int[,] mtx, string direction, int moves, ref int row, ref int col)
        {
            List<int> currScores = new List<int>();
            int performedMoves = 1;


            while (performedMoves < moves)
            {
                switch (direction)
                {
                    case "RU":
                    case "UR":
                        if (InBoundaries(mtx, row - 1, col + 1))
                        {
                            row--;
                            col++;
                            currScores.Add(mtx[row, col]);
                            mtx[row, col] = 0;
                            performedMoves++;
                        }
                        else return currScores;
                        break;
                    case "LU":
                    case "UL":
                       
                        if (InBoundaries(mtx, row - 1, col - 1))
                        {
                            row--;
                            col--;
                            currScores.Add(mtx[row, col]);
                            mtx[row, col] = 0;
                            performedMoves++;
                        }
                        else return currScores;
                        break;
                    case "DL":
                    case "LD":
                        if (InBoundaries(mtx, row + 1, col - 1))
                        {
                            row++;
                            col--;
                            currScores.Add(mtx[row, col]);
                            mtx[row, col] = 0;
                            performedMoves++;
                        }
                        else return currScores;
                        break;

                    case "DR":
                    case "RD":
                        if (InBoundaries(mtx, row + 1, col + 1))
                        {
                            row++;
                            col++;
                            currScores.Add(mtx[row, col]);
                            mtx[row, col] = 0;
                            performedMoves++;
                        }
                        else return currScores;

                        break;
                    default:
                        break;
                }
            }

            return currScores;
        }

        private static bool InBoundaries(int[,] mtx, int r, int c)
        {
            return r < mtx.GetLength(0) && r >= 0 &&
                    c < mtx.GetLength(1) && c >= 0;
        }

        private static void PrintMatrix(int[,] mtx)
        {
            for (int i = 0; i < mtx.GetLength(0); i++)
            {
                for (int j = 0; j < mtx.GetLength(1); j++)
                {
                    Console.Write(mtx[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillDiagonals(int[,] mtx, int value)
        {

            // left side first
            for (int r = mtx.GetLength(0) - 1, c = 0; r >= 0; r--)
            {
                FillDiagonalFromElement(mtx, r, c, value);
                value += 3;
            }
            // top side 
            for (int c = 1, r = 0; c < mtx.GetLength(1); c++)
            {
                FillDiagonalFromElement(mtx, r, c, value);
                value += 3;
            }

        }

        private static void FillDiagonalFromElement(int[,] mtx, int r, int c, int value)
        {
            while ((r < mtx.GetLength(0)) && (c < mtx.GetLength(1)))
            {
                mtx[r, c] = value;
                r++;
                c++;
            }
        }
    }
}

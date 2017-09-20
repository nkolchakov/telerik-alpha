using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Guards
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int guardsCount = int.Parse(Console.ReadLine());

            var mtx = new int[size[0], size[1]];

            for (int i = 0; i < guardsCount; i++)
            {
                string[] guardProps = Console.ReadLine().Split(' ');
                int gX = int.Parse(guardProps[0]);
                int gY = int.Parse(guardProps[1]);
                string watchDirection = guardProps[2];

                mtx[gX, gY] = -1;
                switch (watchDirection)
                {
                    case "U":
                        if (mtx[gX - 1, gY] >= 0)
                        {
                            mtx[gX - 1, gY] = 3;
                        }
                        break;
                    case "R":
                        if (mtx[gX, gY + 1] >= 0)
                        {
                            mtx[gX, gY + 1] = 3;
                        }
                        break;
                    case "D":
                        if (mtx[gX + 1, gY] >= 0)
                        {
                            mtx[gX + 1, gY] = 3;
                        }
                        break;
                    case "L":
                        if (mtx[gX, gY - 1] >= 0)
                        {
                            mtx[gX, gY - 1] = 3;
                        }
                        break;

                    default:
                        break;
                }
            }

            for (int r = 0; r < size[0]; r++)
            {
                for (int c = 0; c < size[1]; c++)
                {
                    int cellSecond = mtx[r, c] > 0 ? 3 : mtx[r, c] == 0 ? 1 : 0;
                    if (mtx[r, c] < 0)
                    {
                        continue;
                    }
                    if (r == 0 && c == 0)
                    {
                        mtx[r, c] = 1 + cellSecond;
                    }
                    else if (r == 0)
                    {
                        if (mtx[r, c - 1] < 0)
                        {
                            cellSecond = 0;
                        }
                        mtx[r, c] = mtx[r, c - 1] + cellSecond;
                    }
                    else if (c == 0)
                    {
                        if (mtx[r - 1, c] < 0)
                        {
                            cellSecond = 0;
                        }
                        mtx[r, c] = mtx[r - 1, c] + cellSecond;
                    }
                    else if (mtx[r - 1, c] < 0 || mtx[r, c - 1] < 0)
                    {
                        mtx[r, c] = Math.Max(mtx[r - 1, c], mtx[r, c - 1]) + cellSecond;
                    }
                }
            }
        }
    }
}

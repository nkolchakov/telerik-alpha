using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HelpDoge
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var finalDestination = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int enemiesCount = int.Parse(Console.ReadLine());

            int rows = size[0];
            int cols = size[1];

            var mtx = new BigInteger[rows, cols];

            for (int i = 0; i < enemiesCount; i++)
            {
                var enemiyCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                mtx[enemiyCoord[0], enemiyCoord[1]] = -1;
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (mtx[r, c] < 0)
                    {
                        continue;
                    }
                    if (r == 0 && c == 0)
                    {
                        mtx[r, c] = 1;
                    }
                    else if (c == 0)
                    {
                        mtx[r, c] = mtx[r - 1, c];
                    }
                    else if (r == 0)
                    {
                        mtx[r, c] = mtx[r, c - 1];
                    }
                    else if (mtx[r, c - 1] < 0 || mtx[r - 1, c] < 0)
                    {
                        mtx[r, c] = BigInteger.Max(mtx[r, c - 1], mtx[r - 1, c]);
                    }
                    else
                    {
                        mtx[r, c] = mtx[r, c - 1] + mtx[r - 1, c];
                    }
                }
            }
            BigInteger res = mtx[finalDestination[0], finalDestination[1]];
            Console.WriteLine(res > 0 ? res : 0 );
        }
    }
}

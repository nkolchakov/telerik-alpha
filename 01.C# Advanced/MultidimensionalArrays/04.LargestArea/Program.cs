using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LargestArea
{

    /*
5 6
1 3 2 2 2 4
3 3 3 2 4 4
4 3 1 2 3 3
4 3 1 3 3 1
4 3 3 3 1 1

3 1
1
1
1
     */
    class Program
    {
        static int[,] mtx;
        static bool[,] visited;
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            mtx = new int[n, m];
            for (int i = 0; i < mtx.GetLength(0); i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    mtx[i, j] = int.Parse(line[j]);
                }
            }

            visited = new bool[n, m];

            int max = int.MinValue;
            for (int r = 0; r < mtx.GetLength(0); r++)
            {
                for (int c = 0; c < mtx.GetLength(1); c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }
                    int curr = RecSearch(r, c);
                    if (max < curr)
                    {
                        max = curr;
                    }
                }
            }
            Console.WriteLine(max);
        }

        static int RecSearch(int r, int c)
        {
            if (visited[r, c])
            {
                return 0;
            }

            int childrenCount = 0;

            visited[r, c] = true;

            if (c - 1 >= 0 && !visited[r, c - 1] && mtx[r, c - 1] == mtx[r, c]) // check left
            {
                childrenCount += RecSearch(r, c - 1);
            }
            if (r + 1 < mtx.GetLength(0) && !visited[r + 1, c] && mtx[r + 1, c] == mtx[r, c]) // down
            {
                childrenCount += RecSearch(r + 1, c);

            }
            if (c + 1 < mtx.GetLength(1) && !visited[r, c + 1] && mtx[r, c + 1] == mtx[r, c]) // right
            {
                childrenCount += RecSearch(r, c + 1);

            }
            if (r - 1 >= 0 && !visited[r - 1, c] && mtx[r - 1, c] == mtx[r, c]) // top
            {
                childrenCount += RecSearch(r - 1, c);
            }
            return childrenCount + 1;
        }

    }
}

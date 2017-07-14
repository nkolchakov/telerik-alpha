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

3 3 
1 1 1 
1 1 1 
1 1 1  
     */
    class Program
    {
        class Node
        {
            public Node(int data, int r, int c)
            {
                this.Data = data;
                this.Row = r;
                this.Col = c;
            }

            public int Data { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
        }
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

            bool[,] visited = new bool[n, m];
            bool[,] markedAsChild = new bool[n, m];

            List<int> maxCount = new List<int>();

            for (int r = 0; r < mtx.GetLength(0); r++)
            {
                for (int c = 0; c < mtx.GetLength(1); c++)
                {
                    //if (visited[r, c])
                    //{
                    //    continue;
                    //}
                    var stack = new Stack<Node>();
                    stack.Push(new Node(mtx[r, c], r, c));

                    int count = 0;
                    while (stack.Count != 0)
                    {
                        var currNode = stack.Pop();
                        count++;
                        if (!visited[currNode.Row, currNode.Col])
                        {
                            visited[currNode.Row, currNode.Col] = true;
                            IEnumerable<Node> neighbours = GetNodeNeighbours(mtx, currNode, visited, markedAsChild);

                            foreach (var neigh in neighbours)
                            {
                                stack.Push(neigh);
                            }
                        }
                    }
                    maxCount.Add(count);

                }
            }

            Console.WriteLine(maxCount.Max() - 1);
        }

        private static IEnumerable<Node> GetNodeNeighbours(int[,] mtx, Node currNode, bool[,] visited, bool[,] marked)
        {
            List<Node> res = new List<Node>();
            int r = currNode.Row;
            int c = currNode.Col;

            // left
            if (c - 1 >= 0)
            {
                if (mtx[r, c - 1] == currNode.Data && !marked[r, c - 1])
                {
                    res.Add(new Node(mtx[r, c - 1], r, c - 1));
                    marked[r, c - 1] = true;
                }
            }

            // top
            if (r - 1 >= 0)
            {
                if (mtx[r - 1, c] == currNode.Data && !marked[r - 1, c])
                {
                    res.Add(new Node(mtx[r - 1, c], r - 1, c));
                    marked[r - 1, c] = true;
                }
            }

            // right
            if (c + 1 < mtx.GetLength(1))
            {
                if (mtx[r, c + 1] == currNode.Data && !marked[r, c + 1])
                {
                    res.Add(new Node(mtx[r, c + 1], r, c + 1));
                    marked[r, c + 1] = true;
                }
            }

            // bottom
            if (r + 1 < mtx.GetLength(0))
            {
                if (mtx[r + 1, c] == currNode.Data && !marked[r + 1, c])
                {
                    res.Add(new Node(mtx[r + 1, c], r + 1, c));
                    marked[r + 1, c] = true;
                }

            }

            return res;
        }
    }
}

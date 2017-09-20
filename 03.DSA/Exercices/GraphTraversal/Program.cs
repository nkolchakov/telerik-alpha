using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> graph = new List<List<int>>
            {
                new List<int>(){1,3}, // 0
                new List<int>(){0,2,3,5}, // 1
                new List<int>(){1,5}, // 2
                new List<int>() {0,1,4,6}, // 3
                new List<int>() {3}, // 4
                new List<int>() {1,2}, // 5
                new List<int>() {3}, // 6

            };

            List<List<int>> disconnectedGraph = new List<List<int>>
            {
                new List<int>(){ },
                new List<int>(){4,5},
                new List<int>(){3,6},
                new List<int>(){2,6,7},
                new List<int>(){1,5},
                new List<int>(){1,4},
                new List<int>(){2, 3},
                new List<int>(){3},
            };

            //Console.WriteLine("--- DFS ---");
            //DFS(graph, 0);
            Console.WriteLine("---- BFS ----");
            //BFS(graph, 0);
            //Console.WriteLine("---- DFS Recursive ----");
            //var visited = new bool[graph.Count];
            DFSRecursive(graph, 0, new bool[graph.Count]);

            //Console.WriteLine("connected components count: " + CountConnectedComponents(disconnectedGraph)); // 3 expected

        }

        static int CountConnectedComponents(List<List<int>> graph)
        {
            int connectedComponents = 0;
            bool[] visited = new bool[graph.Count];

            for (int i = 0; i < graph.Count; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                visited[i] = true;
                BFS(graph, i, visited);
                connectedComponents++;
            }

            return connectedComponents;
        }

        static void BFS(List<List<int>> graph, int startRoot, bool[] visited)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startRoot);
            visited[startRoot] = true;

            while (queue.Count != 0)
            {
                int currEl = queue.Dequeue();
                Console.WriteLine(currEl);

                foreach (int child in graph[currEl])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        static void DFSRecursive(List<List<int>> graph, int root, bool[] visited)
        {
            if (visited[root])
            {
                return;
            }

            Console.WriteLine(root);
            visited[root] = true;
            foreach (int child in graph[root])
            {
                DFSRecursive(graph, child, visited);
            }
        }

        static void DFS(List<List<int>> graph, int startRoot)
        {
            bool[] visited = new bool[graph.Count];
            var stack = new Stack<int>();

            stack.Push(startRoot);
            visited[startRoot] = true;

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();

                Console.WriteLine(currentNode);

                foreach (int childIndex in graph[currentNode])
                {
                    if (!visited[childIndex])
                    {
                        visited[childIndex] = true;
                        stack.Push(childIndex);
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Dictionary<int, List<int>>
            {
                { 2, new List<int>()},
                { 3, new List<int>(){ 8,10} },
                { 5, new List<int>(){ 11 }},
                { 7, new List<int>(){ 11,8}},
                { 8, new List<int>(){ 9 }},
                { 9, new List<int>() },
                { 10, new List<int>(){ } },
                { 11, new List<int>(){ 2,9,10 } }
            };

            var sorted = TopSort(graph);

            Console.WriteLine(string.Join(" ", sorted));
        }

        static Stack<int> TopSort(Dictionary<int, List<int>> graph)
        {
            var visited = new bool[graph.Keys.Max() + 1];
            var topological = new Stack<int>();

            foreach (int child in graph.Keys)
            {
                DFS(graph, child, visited, topological);
            }

            return topological;
        }

        private static void DFS(Dictionary<int, List<int>> graph, int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    DFS(graph, child, visited, sorted);
                }
            }

            sorted.Push(node);
        }
    }
}

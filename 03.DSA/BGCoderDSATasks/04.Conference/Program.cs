using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            var props = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = props[0];
            int lines = props[1];

            var graph = new Dictionary<int, List<int>>();
            var peopleInCompany = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                var parts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int from = parts[0];
                int to = parts[1];

                if (!graph.Keys.Contains(from))
                {
                    graph[from] = new List<int>();
                }
                if (!graph.Keys.Contains(to))
                {
                    graph[to] = new List<int>();
                }
                graph[from].Add(to);
                graph[to].Add(from);

            }

            long loners = n - graph.Keys.Count;

            var peopleCountInCompanies = CountConnectedComponents(graph, n);

            long res = 0;
            for (int i = 0; i < peopleCountInCompanies.Count - 1; i++)
            {
                for (int j = i + 1; j < peopleCountInCompanies.Count; j++)
                {
                    res += peopleCountInCompanies[i] * peopleCountInCompanies[j];
                }
                res += peopleCountInCompanies[i] * loners;
            }
            if (peopleCountInCompanies.Count > 0)
            {
                res += peopleCountInCompanies[peopleCountInCompanies.Count - 1] * loners;
            }
            if (loners > 0)
            {
                res += loners * (loners - 1) / 2;
            }

            Console.WriteLine(res);
        }

        static List<int> CountConnectedComponents(Dictionary<int, List<int>> graph, int n)
        {
            bool[] visited = new bool[n + 1];
            var peopleInCompanies = new List<int>();
            var allKeys = graph.Keys.ToList();
            for (int i = 0; i < allKeys.Count; i++)
            {
                if (visited[allKeys[i]])
                {
                    continue;
                }
                peopleInCompanies.Add(DFS(graph, allKeys[i], visited));
            }

            return peopleInCompanies;
        }



        private static int DFS(Dictionary<int, List<int>> graph, int startRoot, bool[] visited)
        {
            int result = 0;

            if (visited[startRoot])
            {
                return result;
            }
            result++;
            visited[startRoot] = true;
            foreach (int child in graph[startRoot])
            {
                result += DFS(graph, child, visited);
            }

            return result;
        }
    }
}


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependeciesResolving
{
    class Program
    {
        static void Main(string[] args)
        {
            var allPackages = Converter.Deserialize<Dictionary<string, List<string>>>("all_packages.json"); // the graph

            var needToInstall = Converter.Deserialize<Dependency>("dependencies.json").Dependencies.ToList();

            TopologicalSort(allPackages, "backbone");
            Console.WriteLine("All done.");
        }

        public static Stack<string> TopologicalSort(Dictionary<string, List<string>> graph, string startingNode)
        {
            Stack<string> sorted = new Stack<string>();
            HashSet<string> visited = new HashSet<string>();

            Console.WriteLine($"Installing {startingNode}");
            if (graph[startingNode].Count > 0)
            {
                Console.WriteLine($"in order to install {startingNode}, we need {string.Join(" and ", graph[startingNode])}");
            }
            foreach (string child in graph[startingNode])
            {

                if (!visited.Contains(child))
                {
                    TopSortUtil(graph, child, sorted, visited);
                }
            }

            return sorted;
        }

        private static void TopSortUtil(Dictionary<string, List<string>> graph, string node, Stack<string> sorted, HashSet<string> visited)
        {
            visited.Add(node);
            foreach (var childItem in graph[node])
            {
                Console.WriteLine($"in order to install {node}, we need {string.Join(" and ", graph[node])}");
                if (!visited.Contains(childItem))
                {
                    TopSortUtil(graph, childItem, sorted, visited);
                }
            }
            Console.WriteLine($"Installing {node} ...");
            sorted.Push(node);
        }
    }

}

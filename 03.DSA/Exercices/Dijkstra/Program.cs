using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static string GraphInput = @"1 6 14
1 3 9
1 2 7
2 3 10
2 4 15
6 3 2
6 5 9
3 4 11
5 4 6";

        static void Main(string[] args)
        {
            var graph = PopulateGraph();
            Dijkstra(graph);
        }

        static void Dijkstra(List<WeightedNode>[] graph)
        {
            SortedSet<int> queue = new SortedSet<int>();

            var parent = new Dictionary<int, int>();
            var distance = new Dictionary<int, int>();

            int source = 1;

            
        }

        static List<WeightedNode>[] PopulateGraph()
        {
            List<WeightedNode>[] graph = new List<WeightedNode>[7];
            foreach (string line in GraphInput.Split('\n'))
            {
                int[] parts = line.Split(' ').Select(s => int.Parse(s)).ToArray();
                int v1 = parts[0];
                int v2 = parts[1];
                int weight = parts[2];
                if(graph[v1] == null)
                {
                    graph[v1] = new List<WeightedNode>();
                }
                if(graph[v2] == null)
                {
                    graph[v2] = new List<WeightedNode>();
                }
                graph[v1].Add(new WeightedNode(v2, weight));
                graph[v2].Add(new WeightedNode(v1, weight));
            }
            return graph;
        }
    }
}



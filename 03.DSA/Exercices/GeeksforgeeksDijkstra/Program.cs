using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksforgeeksDijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]{
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };

            Dijkstra(graph, 0);
        }

        static void Dijkstra(int[,] graph, int source)
        {
            // create empty bool[] sptSet (that keeps track of vertices included in shortest path tree)
            // create dist int[] from each v from the source
            //      set all v with distance value INF
            // set the source v with distance value 0

            // for node v in graph
            //      
            //      v = minDistance(dist)

            //      for each adj u in v
            //           if graph[v][u] == 0  there is no edge between nodes
            //              return
            //           if distance value of u < distance value of v + edge weight to u and other conditions
            //               distance value of u = distance value of v + edge weight to u
            // 
            //      sptSet[v] = true



            var distance = Enumerable.Repeat(int.MaxValue, graph.GetLength(0)).ToArray();
            bool[] spt = new bool[graph.GetLength(0)];

            distance[source] = 0;


            for (int count = 0; count < graph.GetLength(0); count++)
            {
                int v = FindMinV(distance, spt);
                
                for (int u = 0; u < graph.GetLength(0); u++)
                {
                    if(!spt[u] && graph[v,u] != 0 && distance[u] > distance[v] + graph[v, u])
                    {
                        distance[u] = distance[v] + graph[v, u];
                    }
                }

                spt[v] = true;
            }

            PrintSPT(distance);
        }

        private static void PrintSPT(IList<int> dist)
        {
            for (int i = 0; i < dist.Count; i++)
            {
                Console.WriteLine($"{i}: {dist[i]} far from source");
            }
        }

        private static int FindMinV(IList<int> distance, IList<bool> spt)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < distance.Count; i++)
            {
                if(distance[i] < minValue && spt[i] == false)
                {
                    minValue = distance[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}

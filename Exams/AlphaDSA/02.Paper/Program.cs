using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Paper
{
    class Program
    {
        const int INFINITY = int.MaxValue;

        static List<List<int>> graph = new List<List<int>>();
        static HashSet<int> unusedNodes = new HashSet<int>();
        static int[] parentsCount = Enumerable.Repeat(INFINITY, 10).ToArray();

        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());


            for (int i = 0; i < 10; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < lines; i++)
            {
                var parts = Console.ReadLine()
                    .Split(new string[] { " ", "is" }, 5, StringSplitOptions.RemoveEmptyEntries);

                int firstNode = int.Parse(parts[0]);
                int secondNode = int.Parse(parts[2]);

                if (parentsCount[firstNode] == INFINITY)
                {
                    parentsCount[firstNode] = 0;
                }
                if (parentsCount[secondNode] == INFINITY)
                {
                    parentsCount[secondNode] = 0;
                }

                if (parts[1] == "after")
                {
                    graph[secondNode].Add(firstNode);
                    //if (firstNode != secondNode)
                    {
                        parentsCount[firstNode]++;
                    }

                }
                else
                {
                    graph[firstNode].Add(secondNode);
                    //if (firstNode != secondNode)
                    {
                        parentsCount[secondNode]++;
                    }
                }
                unusedNodes.Add(firstNode);
                unusedNodes.Add(secondNode);
            }
            bool firstIteration = true;
            int zeroValue = parentsCount[0];
            StringBuilder res = new StringBuilder();
            while (!parentsCount.All(n => n == INFINITY))
            {
                if (firstIteration)
                {
                    parentsCount[0] = int.MaxValue;
                }
                int minNodeId = MinElementIdWithNoParents(parentsCount);
                if (firstIteration)
                {
                    parentsCount[0] = zeroValue;
                }
                DecreaseChildrensParents(minNodeId);

                // set as visited
                parentsCount[minNodeId] = int.MaxValue;
                res.Append(minNodeId);


                firstIteration = false;
            }

            Console.WriteLine(res.ToString());

        }
        static void DecreaseChildrensParents(int id)
        {

            graph[id].ForEach(childId => parentsCount[childId]--);
        }

        private static int MinElementIdWithNoParents(int[] parentsCount)
        {
            int minId = -1;
            for (int i = 0; i < parentsCount.Length; i++)
            {
                if (parentsCount[i] == 0)
                {
                    if (minId == -1)
                    {
                        minId = i;
                    }
                    else
                    {
                        if (parentsCount[minId] > parentsCount[i])
                        {
                            minId = i;
                        }
                    }
                }
            }
            return minId;
        }
    }
}

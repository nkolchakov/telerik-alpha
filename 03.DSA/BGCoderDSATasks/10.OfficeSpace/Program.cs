using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.OfficeSpace
{
    class Node
    {
        public Node(int id, int value)
        {
            this.Id = id;
            this.Value = value;
        }

        public int Id { get; set; }
        public int Value { get; set; }
        public bool Visited { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
    class Program
    {
        static bool dfsCycle = false;
        static HashSet<Node> nodesInStack = new HashSet<Node>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int index = 0;
            var nodesTimes = Console.ReadLine().Split(' ')
                .Select(x => new Node(index++, int.Parse(x)))
                .ToArray();

            var parentsCount = new int[n];

            var graph = new Dictionary<Node, List<Node>>();

            // i => zero based node id
            for (int i = 0; i < n; i++)
            {
                var dependencies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (dependencies.Length == 1 && dependencies[0] == 0)
                {
                    continue;
                }
                var currNode = nodesTimes[i];
                foreach (int depId in dependencies)
                {
                    var actualIndex = depId - 1;
                    parentsCount[i]++;
                    var parentNode = nodesTimes[actualIndex];
                    parentNode.Id = actualIndex;
                    if (!graph.ContainsKey(parentNode))
                    {
                        graph[parentNode] = new List<Node>();
                    }
                    graph[parentNode].Add(currNode);
                }

            }
            bool cycles = true;
            for (int i = 0; i < parentsCount.Length; i++)
            {
                if (parentsCount[i] != 0)
                {
                    continue;
                }
                cycles = false;
                DFS(nodesTimes[i], graph);

            }
            Console.WriteLine(cycles || dfsCycle ? new Node(0, -1) : nodesTimes.OrderByDescending(node => node.Value).First());
        }

        static int DFS(Node start, Dictionary<Node, List<Node>> graph)
        {
            if (start.Visited)
            {
                if (nodesInStack.Contains(start))
                {
                    dfsCycle = true;
                }
                return start.Value;
            }
            if (!graph.ContainsKey(start))
            {
                return start.Value;
            }
            nodesInStack.Add(start);
            int max = 0;
            foreach (Node child in graph[start])
            {
                start.Visited = true;
                int curr = DFS(child, graph);
                if (curr > max)
                {
                    max = curr;
                }
            }
            nodesInStack.Remove(start);
            start.Value += max;
            return start.Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class WeightedNode : IComparable<WeightedNode>
    {

        public WeightedNode(int vertex, int weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public int Vertex { get; set; }
        public int Weight { get; set; }

        public int CompareTo(WeightedNode other)
        {
            if(this.Weight == other.Weight)
            {
                return this.Vertex.CompareTo(other.Vertex);
            }
            return this.Weight.CompareTo(other.Weight);
        }
    }
}

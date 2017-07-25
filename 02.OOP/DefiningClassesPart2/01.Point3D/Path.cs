using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    [Serializable]
    public class Path
    {
        private ICollection<Point3D> path;

        public Path(IEnumerable<Point3D> points = null)
        {
            this.path = new List<Point3D>(points);
        }

        public void AddPoint(Point3D p)
        {
            this.path.Add(p);
        }

        public IEnumerable<Point3D> PointsInPath
        {
            get
            {
                return this.path;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------Path--------");
            foreach (var point in this.path)
            {
                sb.Append(point);
            }
            return sb.ToString();
        }
    }
}

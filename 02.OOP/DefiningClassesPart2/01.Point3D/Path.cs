using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    public class Path
    {
        private IEnumerable<Point3D> path;
        
        public Path(IEnumerable<Point3D> points = null)
        {
            this.path = new List<Point3D>(points);
        }
    }
}

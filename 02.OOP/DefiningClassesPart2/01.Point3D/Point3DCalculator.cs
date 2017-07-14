using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    public static class Point3DCalculator
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(
                Math.Pow((p1.X - p2.X), 2) +
                Math.Pow((p1.Y - p2.Y), 2) +
                Math.Pow((p1.Z - p2.Z), 2));
        }
    }
}

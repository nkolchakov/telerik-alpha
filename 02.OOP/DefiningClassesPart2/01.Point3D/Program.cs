using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point3D(0, 0, 0);
            var p2 = new Point3D(1, 2, 3);

            Console.WriteLine(Point3DCalculator.CalculateDistance(p1,p2));


        }
    }
}

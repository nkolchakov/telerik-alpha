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

            Console.WriteLine("Distance: " + Point3DCalculator.CalculateDistance(p1, p2));

            Path path = new Path(new List<Point3D>()
            {
                p1,p2
            });

            StoragePath.SaveToFile(path, "file.bin");

            var loadedFile = StoragePath.LoadFromFile("file.bin");
            Console.WriteLine("Loaded file: " + loadedFile);
        }
    }
}

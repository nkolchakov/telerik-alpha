using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    public struct Point3D
    {
        private static readonly Point3D start;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        static Point3D()
        {
            start = new Point3D(0, 0, 0);
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D O
        {
            get
            {
                return start;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----- Point ------");
            sb.AppendFormat("X = {0}\nY = {1}\nZ = {2}\n", this.X, this.Y, this.Z);
            sb.AppendLine("------------------");

            return sb.ToString();
        }
    }
}

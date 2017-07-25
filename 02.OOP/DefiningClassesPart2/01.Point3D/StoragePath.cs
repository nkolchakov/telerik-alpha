using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    public static class StoragePath
    {
        public static Path LoadFromFile(string filename)
        {
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Path path = (Path)formatter.Deserialize(stream);
                return path;
            }
        }

        public static void SaveToFile(Path p, string filename)
        {
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, p);
            }   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHomework
{
    public class EntryPoint
    {
        public static void Main()
        {
            var data = new List<int> { 5, 0, -10, 3, 11, 500, -23, 1000, 7 };
            data.Sort();
            SortableCollection<int> s = new SortableCollection<int>(data);
            Console.WriteLine("Before ");
            Console.WriteLine(string.Join(" ",s.Items));

            s.Shuffle();
            Console.WriteLine("After shuffle ");
            Console.WriteLine(string.Join(" ",s.Items));
            Console.WriteLine(s.BinarySearch(-22));
        }
    }
}

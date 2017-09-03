using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.AquaPark
{
    class Program
    {
        static void Main(string[] args)
        {
            var deque = new Deque<int>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var parts = Console.ReadLine().Split(' ');
                string command = parts[0];

                switch (command)
                {
                    case "add":
                        int id = int.Parse(parts[1]);
                        deque.AddToBack(id);
                        Console.WriteLine("Added " + id);
                        break;
                    case "slide":
                        int sliders = int.Parse(parts[1]);
                        int k = sliders;
                        while (sliders > 0 && deque.Count > 0)
                        {
                            var front = deque.GetAtFront();
                            deque.RemoveFromFront();
                            deque.AddToBack(front);
                            sliders--;
                        }

                        Console.WriteLine("Slided " + k);
                        break;

                    case "print":
                        var listToPrint = new List<int>(deque);
                        StringBuilder sb = new StringBuilder();

                        for (int j = listToPrint.Count - 1; j >= 0; j--)
                        {
                            sb.Append(listToPrint[j] + " ");
                        }
                        Console.WriteLine(sb.ToString().TrimEnd());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}

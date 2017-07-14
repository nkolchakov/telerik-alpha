using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            double input;
            try
            {
                input = double.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw new ArgumentException("");
                }
                Console.WriteLine(String.Format("{0:0.000}", Math.Sqrt(input)));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}

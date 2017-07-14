using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.StringLength
{
    class Program
    {
        const int MAX_LENGTH = 20;
        const char SYMBOL = '*';

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string res = Fill(input);

            Console.WriteLine(res);
        }

        private static string Fill(string input)
        {
            return input.PadRight(MAX_LENGTH, SYMBOL);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.UnicodeCharacters
{
    class Program
    {
        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4");
        }

        public static string ToUnicode(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in input)
            {
                sb.Append(GetEscapeSequence(ch));
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(ToUnicode(input));
        }
    }
}

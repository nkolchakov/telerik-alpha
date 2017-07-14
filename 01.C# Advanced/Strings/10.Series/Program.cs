using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string res = Normalize(input);
            Console.WriteLine(res);
        }

        static string Normalize(string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text[0]);

            for (int i = 0; i < text.Length - 1; i++)
            {
                if(text[i] != text[i + 1])
                {
                    sb.Append(text[i+1]);
                }
            }

            return sb.ToString();
        }
    }
}

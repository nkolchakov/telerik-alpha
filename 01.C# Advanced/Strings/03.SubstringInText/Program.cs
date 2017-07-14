using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SubstringInText
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = Console.ReadLine();
            string input = Console.ReadLine();

            int times = CheckOccurences(input, target);
            Console.WriteLine(times);
        }

        private static int CheckOccurences(string text, string substring)
        {
            int count = 0;
            for (int i = 0; i < text.Length - substring.Length + 1; i++)
            {
                if (text[i].ToString().ToUpper() == substring[0].ToString().ToUpper())
                {
                    bool same = true;
                    for (int j = i + 1, k = 1; k < substring.Length; j++, k++)
                    {
                        if (text[j].ToString().ToUpper() != substring[k].ToString().ToUpper())
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

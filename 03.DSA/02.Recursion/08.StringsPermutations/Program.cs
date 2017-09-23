using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.StringsPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Permutate(s);

        }

        private static void Permutate(string text)
        {
            Rec(text, "");
        }

        private static void Rec(string text, string result)
        {
            if (text.Length == 0)
            {
                Console.WriteLine(result);
                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                char chosen = text[i];

                result += chosen;
                text = text.Remove(i, 1);

                Rec(text, result);

                text += chosen;
                result = result.Remove(result.Length - 1, 1);
            }
        }
    }
}

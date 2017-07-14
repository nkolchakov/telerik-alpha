using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ExtractSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string res = ExtractSentence(text, word);
            Console.WriteLine(res);
        }

        private static string ExtractSentence(string text, string word)
        {
            var sentences = text.Split('.');
            StringBuilder res = new StringBuilder();
            foreach (var s in sentences)
            {
                bool newWord = true;
                StringBuilder buffer = new StringBuilder();
                foreach (var ch in s)
                {
                    if (char.IsLetter(ch))
                    {
                        buffer.Append(ch);
                    }
                    else
                    {
                        newWord = !newWord;
                        if (buffer.ToString() == word)
                        {
                            res.Append(s);
                            res.Append('.');
                            break;
                        }
                        buffer.Clear();
                    }
                }
            }
            return res.ToString();
        }
    }
}

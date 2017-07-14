using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ParseTags
{
    class Program
    {
        const string OPENING = "<upcase>";
        const string CLOSING = "</upcase>";

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //string res = Transform(input);
            string res = RegexTransform(input);
            Console.WriteLine(res);
        }

        private static string RegexTransform(string input)
        {
            StringBuilder sb = new StringBuilder(input);
            Regex pattern = new Regex("<upcase>(.*?)</upcase>"); 
            var matches = pattern.Matches(input);

            foreach (Match match in matches)
            {
                string txt = match.Groups[1].Value.ToUpper();
                sb = sb.Replace(match.Value, txt);
            }
            return sb.ToString() ;
        }

        private static string Transform(string input)
        {
            StringBuilder sb = new StringBuilder();

            int index = 0;
            int openingIndex = 0;
            int closingIndex = 0;

            bool readUpper = false;

            while (index < input.Length)
            {
                if (input[index++] == OPENING[openingIndex])
                {
                    if (OPENING[openingIndex] == '>')
                    {
                        readUpper = true;
                    }
                }
                else
                {
                    openingIndex = 0;
                }
                if (readUpper)
                {
                    sb.Append(input[index]);
                }
            }

            return sb.ToString();
        }
    }
}

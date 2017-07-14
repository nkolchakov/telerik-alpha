using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.ReplaceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string parsed = RegexParse(text);
            Console.WriteLine(parsed);
        }

        private static string RegexParse(string text)
        {
            string res = text;
            //<a href="http://academy.telerik.com">our site</a>
            Regex pattern = new Regex("<a href=\"(.*?)\">(.*?)</a>");
            var matches = pattern.Matches(text);

            foreach (Match match in matches)
            {
                string url = match.Groups[1].Value;
                string content = match.Groups[2].Value;

                string parsedMd = ParseToMd(content, url);
                res = res.Replace(match.Value, parsedMd);
            }
            return res;
        }

        private static string ParseToMd(string content, string url)
        {
            return String.Format("[{0}]({1})", content, url);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ParseURL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            string res = ParseUrl(url);
            Console.WriteLine(res);
        }

        public static string ParseUrl(string input)
        {
            StringBuilder sb = new StringBuilder();

            var protocolAndRest = input.Split(':');
            string protocol = protocolAndRest[0];

            var rest = protocolAndRest[1];
            var serverAndResource = string.Join("", rest.Skip(2).ToArray()).Split('/');

            string server = serverAndResource[0];

            string resource = "/" + string.Join("/", serverAndResource.Skip(1).ToArray());

            sb.Append(string.Format("[protocol] = {0}\n", protocol));
            sb.Append(string.Format("[server] = {0}\n", server));
            sb.Append(string.Format("[resource] = {0}", resource));

            return sb.ToString();
        }
    }
}

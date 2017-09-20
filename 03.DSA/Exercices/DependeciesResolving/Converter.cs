using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependeciesResolving
{
    public class Converter
    {
        public static T Deserialize<T>(string jsonPath)
        {
            StringBuilder content = new StringBuilder();
            using (StreamReader sr = new StreamReader("../../" + jsonPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    content.Append(line);
                }
            }

            return JsonConvert.DeserializeObject<T>(content.ToString());
        }
    }
}

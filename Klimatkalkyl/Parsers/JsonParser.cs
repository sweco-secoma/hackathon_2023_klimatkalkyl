using Klimatkalkyl.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Klimatkalkyl.Parsers
{
    internal class JsonParser
    {
        protected string PathToJsonClimateFile = "..\\..\\..\\Climate.json";


        public JsonParser()
        {
        }

        public List<Resource> ParseResourceFile()
        {
            using (StreamReader reader = new StreamReader(PathToJsonClimateFile))
            {
                string json = reader.ReadToEnd();
                List<Resource> resources = JsonSerializer.Deserialize<List<Resource>>(json);

                return resources;
            }
        }

        public static Resource? GetResource(List<Resource> resources, string resourceName)
        {
            var betong_Part = resources.Where(x => x.Namn.ToLower().Contains(resourceName));

            return betong_Part.FirstOrDefault();
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class TerrainDefinition
    {
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public TerrainDefinition()
        {

        }

        public JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("textures", Path);
            return new JProperty(Name, jObject);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Blocks
{
    public class BlockDefinition
    {
        public string Identifier { get; set; }
        public Dictionary<string, TerrainDefinition> Textures;
        public string Sound { get; set; } = "";

        public BlockDefinition()
        {
            Textures = new Dictionary<string, TerrainDefinition>();
        }

        public JProperty Generate()
        {
            JObject jObject = new JObject();
            if (Textures.Count == 1)
                jObject.Add("textures", Textures.First().Value.Name);
            else
            {
                JObject textures = new JObject();
                jObject.Add("textures", textures);

                foreach (KeyValuePair<string, TerrainDefinition> tex in Textures)
                    textures.Add(tex.Key, tex.Value.Name);
            }

            if (!string.IsNullOrEmpty(Sound))
                jObject.Add("sound", Sound);

            return new JProperty(Identifier, jObject);
        }
    }
}

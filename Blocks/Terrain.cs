using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class Terrain
    {
        public string ResourcePackName { get; set; } = "vanilla";
        public string TextureName { get; set; } = "atlas.terrain";
        public long Padding { get; set; } = 8;
        public long MipMapLevel { get; set; } = 4;
        public List<TerrainDefinition> TerrainData { get; set; }

        public Terrain()
        {
            TerrainData = new List<TerrainDefinition>();
        }

        public JObject Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("resource_pack_name", ResourcePackName);
            jObject.Add("texture_name", TextureName);
            jObject.Add("padding", Padding);
            jObject.Add("num_mip_levels", MipMapLevel);

            JObject data = new JObject();
            jObject.Add("texture_data", data);

            foreach (TerrainDefinition td in TerrainData)
            {
                data.Add(td.Generate());
            }

            return jObject;
        }
    }
}

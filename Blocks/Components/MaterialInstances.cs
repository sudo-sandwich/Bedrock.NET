using Bedrock.Blocks.Components.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class MaterialInstances : BlockComponentBase
    {
        public Dictionary<string, MaterialInstance> Instances { get; set; }
        public MaterialInstances()
        {
            Instances = new Dictionary<string, MaterialInstance>();
            Name = "minecraft:material_instances";
        }
        public override JProperty Generate()
        {
            JObject jObject = new JObject();

            foreach (KeyValuePair<string, MaterialInstance> mats in Instances)
            {
                JObject shard = new JObject();

                if (mats.Value.TerrainDefinition != null)
                    shard.Add("texture", mats.Value.TerrainDefinition.Name);
                else
                    shard.Add(new JProperty("texture", mats.Value.Texture));

                shard.Add(new JProperty("render_method", mats.Value.RenderMethod));
                jObject.Add(mats.Key, shard);
            }

            return new JProperty(Name, jObject);
        }
    }
}

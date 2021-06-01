using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class SpawnLoot : BlockEventResponse
    {
        public string Table { get; set; } = " ";

        public SpawnLoot()
        {
            Name = "spawn_loot";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("target", Table);
            return new JProperty(Name, jObject);
        }
    }
}

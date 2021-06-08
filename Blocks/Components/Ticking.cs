using Bedrock.Blocks.Events;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Ticking : BlockComponentBase
    {
        public bool? Looping { get; set; }
        public int[] Range { get; set; }
        public BlockEvent Event { get; set; }

        public Ticking()
        {
            Name = "minecraft:ticking";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (Looping != null) jObject.Add("looping", Looping);
            if (Range != null) jObject.Add("range", new JArray(Range));

            JObject OnTick = new JObject();
            OnTick.Add("event", Event.Name);
            jObject.Add("on_tick", OnTick);
            return new JProperty(Name, jObject);
        }
    }
}

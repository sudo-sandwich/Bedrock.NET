using Bedrock.Entities.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class OnFallOn : BlockComponentBase
    {
        public string Condition { get; set; } = "";
        public string Event { get; set; } = "";
        public float MinFallDistance { get; set; } = 0f;
        public string Target { get; set; } = "self";


        public OnFallOn()
        {
            Name = "minecraft:on_fall_on";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Condition)) jObject.Add("condition", Condition);
            if (!string.IsNullOrEmpty(Event)) jObject.Add("event", Event);
            if (MinFallDistance != 0f) jObject.Add("min_fall_distance", MinFallDistance);
            if (!Target.Equals("self")) jObject.Add("target", Target);
            return new JProperty(Name, jObject);
        }
    }
}

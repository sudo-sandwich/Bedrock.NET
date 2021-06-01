using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class OnPlayerPlacing : BlockComponentBase
    {
        public string Condition { get; set; } = "";
        public string Event { get; set; } = "";
        public string Target { get; set; } = "self";

        public OnPlayerPlacing()
        {
            Name = "minecraft:on_player_placing";
        }
        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Condition)) jObject.Add("condition", Condition);
            if (!string.IsNullOrEmpty(Event)) jObject.Add("event", Event);
            if (!Target.Equals("self")) jObject.Add("target", Target);
            return new JProperty(Name, jObject);
        }
    }
}

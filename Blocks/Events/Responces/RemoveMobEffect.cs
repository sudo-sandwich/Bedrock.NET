using Bedrock.Entities.Server.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class RemoveMobEffect : BlockEventResponse
    {
        public string Effect { get; set; } = "";
        public FilterTest Target { get; set; }

        public RemoveMobEffect()
        {
            Name = "remove_mob_effect";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("effect", Effect);
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

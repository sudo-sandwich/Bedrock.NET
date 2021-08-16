using Bedrock.Entities.Server.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class PlayEffect : BlockEventResponse
    {
        public int? Data { get; set; }
        public string Effect { get; set; } = "";
        public FilterTest Target { get; set; }

        public PlayEffect()
        {
            Name = "play_effect";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Effect)) jObject.Add("effect", Effect);
            if (Data != null) jObject.Add("data", Data);
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

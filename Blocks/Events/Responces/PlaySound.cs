using Bedrock.Entities.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class PlaySound : BlockEventResponse
    {
        public string Sound { get; set; } = "";
        public FilterTest Target { get; set; }

        public PlaySound()
        {
            Name = "play_sound";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("sound", Sound);
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

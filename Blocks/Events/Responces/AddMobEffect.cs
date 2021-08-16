using Bedrock.Entities.Server.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class AddMobEffect : BlockEventResponse
    {
        public int? Amplifier { get; set; }
        public float? Duration { get; set; }
        public string Effect { get; set; } = "";

        // TODO: this might not work.
        public FilterTest Target { get; set; }

        public AddMobEffect()
        {
            Name = "add_mob_effect";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Effect)) jObject.Add("effect", Effect);
            if (Amplifier != null) jObject.Add("amplifier", Amplifier);
            if (Duration != null) jObject.Add("duration", Duration);
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Entities.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class Die : BlockEventResponse
    {
        public FilterTest Target { get; set; }

        public Die()
        {
            Name = "die";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

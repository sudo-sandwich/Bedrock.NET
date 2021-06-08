using Bedrock.Entities.Components.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class Damage : BlockEventResponse
    {
        public int? Amount { get; set; }
        public FilterTest Target { get; set; }
        public string Type { get; set; } = "";

        public Damage()
        {
            Name = "damage";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Type)) jObject.Add("type", Type);
            if (Amount != null) jObject.Add("amount", Amount);
            if (Target != null) jObject.Add("target", Target.ToJObject());
            return new JProperty(Name, jObject);
        }
    }
}

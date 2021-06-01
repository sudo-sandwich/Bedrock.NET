using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class Trigger : BlockEventResponse
    {
        public string Event { get; set; } = "";

        public Trigger()
        {
            Name = "trigger";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Event)) jObject.Add("event", Event);
            return new JProperty(Name, jObject);
        }
    }
}

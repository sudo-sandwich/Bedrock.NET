using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class TransformItem : BlockEventResponse
    {
        public string Value { get; set; }
        public TransformItem()
        {
            Name = "transform_item";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add(new JProperty("transform", Value));
            return new JProperty(Name, jObject);
        }
    }
}

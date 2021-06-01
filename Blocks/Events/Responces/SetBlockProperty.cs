using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class SetBlockProperty : BlockEventResponse
    {
        public string Property { get; set; } = " ";
        public string Value { get; set; } = " ";

        public SetBlockProperty()
        {
            Name = "set_block_property";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add(Property, Value);
            return new JProperty(Name, jObject);
        }
    }
}

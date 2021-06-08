using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class SetBlock : BlockEventResponse
    {
        public string BlockType { get; set; } = " ";

        public SetBlock()
        {
            Name = "set_block";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("block_type", BlockType);
            return new JProperty(Name, jObject);
        }
    }
}

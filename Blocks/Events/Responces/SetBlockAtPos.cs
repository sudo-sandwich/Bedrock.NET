using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class SetBlockAtPos : BlockEventResponse
    {
#pragma warning disable CA1819 // Properties should not return arrays
        // bruh, I told you already, it ok... ffs compiler
        public float?[] BlockOffset { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public string BlockType { get; set; } = " ";

        public SetBlockAtPos()
        {
            Name = "set_block_at_pos";
        }

        public override JProperty Generate()
        {
            JObject jObject = new JObject();
            if (BlockOffset != null) jObject.Add("block_offset", new JArray(BlockOffset));
            jObject.Add("block_type", BlockType);
            return new JProperty("Name", jObject);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class BreakOnPush : BlockComponentBase
    {
        public bool Value { get; set; } = false;
        public BreakOnPush()
        {
            Name = "minecraft:breakonpush";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class OnlyPistonPush : BlockComponentBase
    {
        public bool Value { get; set; } = false;
        public OnlyPistonPush()
        {
            Name = "minecraft:onlypistonpush";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

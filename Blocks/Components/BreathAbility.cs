using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class BreathAbility : BlockComponentBase
    {
        public BlockProperty Value { get; set; }
        public BreathAbility()
        {
            Name = "minecraft:breathability";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value.ToString());
        }
    }
}

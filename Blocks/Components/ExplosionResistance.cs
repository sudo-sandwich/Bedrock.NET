using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class ExplosionResistance : BlockComponentBase
    {
        public float Value { get; set; } = 0f;

        public ExplosionResistance()
        {
            Name = "minecraft:explosion_resistance";
        }
        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

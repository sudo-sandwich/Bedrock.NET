using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Friction : BlockComponentBase
    {
        public float Value { get; set; } = 0f;
        public Friction()
        {
            Name = "minecraft:friction";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

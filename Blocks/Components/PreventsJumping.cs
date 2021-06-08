using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class PreventsJumping : BlockComponentBase
    {
        public bool Value { get; set; } = false;

        public PreventsJumping()
        {
            Name = "minecraft:preventsjumping";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

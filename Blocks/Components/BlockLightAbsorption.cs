using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class BlockLightAbsorption : BlockComponentBase
    {
        public int Value { get; set; } = 0;

        public BlockLightAbsorption()
        {
            Name = "minecraft:block_light_absorption";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

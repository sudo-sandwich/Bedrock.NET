using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Immovable : BlockComponentBase
    {
        public bool Value { get; set; } = false;
        public Immovable()
        {
            Name = "minecraft:imovable";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

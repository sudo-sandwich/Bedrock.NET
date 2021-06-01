using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Geometry : BlockComponentBase
    {
        public string Value { get; set; } = "";
        public Geometry()
        {
            Name = "minecraft:geometry";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

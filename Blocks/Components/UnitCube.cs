using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class UnitCube : BlockComponentBase
    {
        public string Value { get; set; }

        public UnitCube()
        {
            Name = "minecraft:unit_cube";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

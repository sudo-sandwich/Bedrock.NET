using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class MapColor : BlockComponentBase
    {
        public string Value { get; set; } = "";
        public MapColor()
        {
            Name = "minecraft:map_color";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

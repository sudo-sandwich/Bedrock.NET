using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class DisplayName : BlockComponentBase
    {
        public string Value { get; set; } = "";
        public DisplayName()
        {
            Name = "minecraft:display_name";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

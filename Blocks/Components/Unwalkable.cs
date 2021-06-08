using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Unwalkable : BlockComponentBase
    {
        public bool? Value { get; set; }

        public Unwalkable()
        {
            Name = "minecraft:unwalkable";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

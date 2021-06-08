using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Rotation : BlockComponentBase
    {
        public int[] Vector { get; set; }

        public Rotation()
        {
            Name = "minecraft:rotation";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, new JArray(Vector));
        }
    }
}

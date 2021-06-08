using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class DestroyTime : BlockComponentBase
    {
        public float Value { get; set; } = 0f;
        public DestroyTime()
        {
            Name = "minecraft:destroy_time";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name, Value);
        }
    }
}

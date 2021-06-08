using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public class Tag : BlockComponentBase
    {
        public string Value { get; set; } = "";

        public Tag()
        {
            Name = "tag:";
        }
        public override JProperty Generate()
        {
            return new JProperty($"Name{Value}");
        }
    }
}

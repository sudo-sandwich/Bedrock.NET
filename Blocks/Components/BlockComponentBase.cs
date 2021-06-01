using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Components
{
    public abstract class BlockComponentBase
    {
        public string Name { get; set; }

        public abstract JProperty Generate();
    }

    public enum BlockProperty
    {
        solid = 0,
        air = 1
    }
}

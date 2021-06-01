using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public abstract class BlockEventResponse
    {
        public string Name { get; set; }
        public abstract JProperty Generate();
    }
}

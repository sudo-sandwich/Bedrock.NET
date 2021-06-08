using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class DecrementStack : BlockEventResponse
    {
        public DecrementStack()
        {
            Name = "decrement_stack";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name);
        }
    }
}

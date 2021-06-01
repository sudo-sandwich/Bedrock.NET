using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks.Events.Responces
{
    public class Swing : BlockEventResponse
    {
        public Swing()
        {
            Name = "swing";
        }

        public override JProperty Generate()
        {
            return new JProperty(Name);
        }
    }
}

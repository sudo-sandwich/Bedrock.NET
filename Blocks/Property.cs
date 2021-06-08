using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class Property
    {
        public string Name { get; set; } = "";
        public string[] StringArray { get; set; } = null;
        public bool[] BoolArray { get; set; } = null;
        public int[] IntArray { get; set; } = null;

        public Property()
        {

        }

        public JProperty Generate()
        {
            if (StringArray != null) return new JProperty(Name, new JArray(StringArray));
            if (BoolArray != null) return new JProperty(Name, new JArray(BoolArray));
            if (IntArray != null) return new JProperty(Name, new JArray(IntArray));
            return null;
        }
    }
}

using Bedrock.Blocks.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class Permutation
    {
        public string Condition { get; set; }
        public List<BlockComponentBase> Components { get; set; } = new List<BlockComponentBase>();

        public JObject Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("condition", Condition);

            JObject comps = new JObject();
            jObject.Add("components", comps);

            foreach (BlockComponentBase c in Components)
                comps.Add(c.Generate());
            return jObject;
        }
    }
}

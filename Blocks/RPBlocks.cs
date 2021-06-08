using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Blocks
{
    public class RPBlocks
    {
        public int[] FormatVersion { get; set; } = new int[] { 1, 1, 0 };
        public List<BlockDefinition> Definitions { get; set; }

        public RPBlocks()
        {
            Definitions = new List<BlockDefinition>();
        }

        public JObject Generate()
        {
            JObject jObject = new JObject();
            jObject.Add("format_version", new JArray(FormatVersion));

            if (Definitions.Count > 0)
            {
                foreach (BlockDefinition bd in Definitions)
                    jObject.Add(bd.Generate());
            }

            return jObject;
        }
    }
}

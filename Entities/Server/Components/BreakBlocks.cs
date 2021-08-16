using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class BreakBlocks : IComponent {
        public string Name => "minecraft:break_blocks";

        public IList<string> BreakableBlocks { get; set; } = new List<string>();

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "breakable_blocks", new JArray(BreakableBlocks) }
            };

            return new JProperty(Name, jObject);
        }
    }
}

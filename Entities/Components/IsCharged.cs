using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class IsCharged : IComponent {
        public string Name => "minecraft:is_charged";

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

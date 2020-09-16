using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class FireImmune : IComponent {
        public string Name => "minecraft:fire_immune";

        public JProperty Generate() => new JProperty(Name, new JObject());
    }
}

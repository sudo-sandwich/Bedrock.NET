using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class IsSheared : IComponent {
        public string Name {
            get {
                return "minecraft:is_sheared";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

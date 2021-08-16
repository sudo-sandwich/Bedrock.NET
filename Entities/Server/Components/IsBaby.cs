using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class IsBaby : IComponent {
        public string Name {
            get {
                return "minecraft:is_baby";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

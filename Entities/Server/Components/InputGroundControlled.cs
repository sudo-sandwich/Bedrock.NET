using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class InputGroundControlled : IComponent {
        public string Name {
            get {
                return "minecraft:input_ground_controlled";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

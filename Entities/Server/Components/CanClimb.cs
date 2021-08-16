using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class CanClimb : IComponent {
        public string Name {
            get {
                return "minecraft:can_climb";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

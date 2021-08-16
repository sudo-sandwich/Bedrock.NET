using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class CanPowerJump : IComponent {
        public string Name {
            get {
                return "minecraft:can_power_jump";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}

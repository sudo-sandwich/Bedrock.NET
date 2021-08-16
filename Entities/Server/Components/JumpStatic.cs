using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class JumpStatic : IComponent {
        public string Name {
            get {
                return "minecraft:jump.static";
            }
        }

        public double? JumpPower { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("jump_power", JumpPower);

            return new JProperty(Name, jObject);
        }
    }
}

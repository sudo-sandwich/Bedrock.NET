using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorFloat : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.float";
            }
        }
        public int Priority { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            return new JProperty(Name, jObject);
        }
    }
}

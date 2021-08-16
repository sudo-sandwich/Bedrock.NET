using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorOwnerHurtTarget : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.owner_hurt_target";
            }
        }

        public int Priority { get; set; }
        //entity_types not implemented

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            return new JProperty(Name, jObject);
        }
    }
}

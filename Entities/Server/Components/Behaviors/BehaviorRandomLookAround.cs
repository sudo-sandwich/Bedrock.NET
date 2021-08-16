using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorRandomLookAround : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.random_look_around";
            }
        }
        public int Priority { get; set; }

        public Range<int> LookTime { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("look_time", LookTime);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorMoveToRandomBlock : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.move_to_random_block";
            }
        }
        public int Priority { get; set; }

        public double? SpeedMultiplier { get; set; }
        public int? WithinRadius { get; set; }
        public int? BlockDistance { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("within_radius", WithinRadius);
            jObject.AddIfNotNull("block_distance", BlockDistance);

            return new JProperty(Name, jObject);
        }
    }
}

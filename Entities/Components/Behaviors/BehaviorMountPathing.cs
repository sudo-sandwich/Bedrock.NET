using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorMountPathing : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.mount_pathing";
            }
        }

        public int Priority { get; set; }
        public double? SpeedMultiplier { get; set; }
        public double? TargetDist { get; set; }
        public bool? TrackTarget { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("target_dist", TargetDist);
            jObject.AddIfNotNull("track_target", TrackTarget);

            return new JProperty(Name, jObject);
        }
    }
}

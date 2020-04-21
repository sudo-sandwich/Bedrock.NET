using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorFollowOwner : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.follow_owner";
            }
        }

        public int Priority { get; set; }
        public double? SpeedMultiplier { get; set; }
        public double? StartDistance { get; set; }
        public double? StopDistance { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("priority", Priority);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("start_distance", StartDistance);
            jObject.AddIfNotNull("stop_distance", StopDistance);

            return new JProperty(Name, jObject);
        }
    }
}

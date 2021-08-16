using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorRandomStroll : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.random_stroll";
            }
        }
        public int Priority { get; set; }

        public double? SpeedMultiplier { get; set; }
        public int? XZDist { get; set; }
        public int? YDist { get; set; }
        public int? Interval { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("xz_dist", XZDist);
            jObject.AddIfNotNull("y_dist", YDist);
            jObject.AddIfNotNull("interval", Interval);

            return new JProperty(Name, jObject);
        }
    }
}

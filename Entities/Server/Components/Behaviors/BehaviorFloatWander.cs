using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorFloatWander : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.float_wander";
            }
        }
        public int Priority { get; set; }

        public int? XZDist { get; set; }
        public int? YDist { get; set; }
        public double? YOffset { get; set; }
        public bool? MustReach { get; set; }
        public bool? RandomReselect { get; set; }
        public Range<double> FloatDuration { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("xz_dist", XZDist);
            jObject.AddIfNotNull("y_dist", YDist);
            jObject.AddIfNotNull("y_offset", YOffset);
            jObject.AddIfNotNull("must_reach", MustReach);
            jObject.AddIfNotNull("random_reselect", RandomReselect);
            jObject.AddIfNotNull("xz_dist", FloatDuration);

            return new JProperty(Name, jObject);
        }
    }
}

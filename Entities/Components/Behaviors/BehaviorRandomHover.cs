using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorRandomHover : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.random_hover";
            }
        }
        public int Priority { get; set; }

        public int? XZDist { get; set; }
        public int? YDist { get; set; }
        public int? YOffset { get; set; } //found in parrot template, not present in documentation
        public double? SpeedMultiplier { get; set; } //found in parrot template, not present in documentation
        public int? Interval { get; set; }
        public Range<int> HoverHeight { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("xz_dist", XZDist);
            jObject.AddIfNotNull("y_dist", YDist);
            jObject.AddIfNotNull("y_offset", YOffset);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("interval", Interval);
            jObject.AddIfNotNull("hover_height", HoverHeight);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorRandomFly : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.random_fly";
            }
        }
        public int Priority { get; set; }

        public int? XZDist { get; set; }
        public int? YDist { get; set; }
        public int? YOffset { get; set; } //found in parrot template, not present in documentation
        public double? SpeedMultiplier { get; set; } //found in parrot template, not present in documentation
        public bool? CanLandOnTrees { get; set; }
        public bool? AvoidDamageBlocks { get; set; } //found in parrot template, not present in documentation

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("xz_dist", XZDist);
            jObject.AddIfNotNull("y_dist", YDist);
            jObject.AddIfNotNull("y_offset", YOffset);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("can_land_on_trees", CanLandOnTrees);
            jObject.AddIfNotNull("avoid_damage_blocks", AvoidDamageBlocks);

            return new JProperty(Name, jObject);
        }
    }
}

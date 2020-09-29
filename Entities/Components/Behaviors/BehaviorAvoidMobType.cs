using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorAvoidMobType : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.avoid_mob_type";
            }
        }

        public int Priority { get; set; }
        public IList<EntityType> EntityTypes { get; set; } = new List<EntityType>();
        public double? MaxDist { get; set; }
        public double? MaxFlee { get; set; }
        public double? WalkSpeedMultiplier { get; set; }
        public double? SprintSpeedMultiplier { get; set; }
        public double? ProbabilityPerStrength { get; set; }
        public bool? IgnoreVisibility { get; set; }

        public BehaviorAvoidMobType(params EntityType[] entityTypes) {
            EntityTypes = entityTypes;
        }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EntityTypes.Count > 0) {
                jObject.Add("entity_types", EntityTypes.ToJArray());
            }
            jObject.AddIfNotNull("max_dist", MaxDist);
            jObject.AddIfNotNull("max_flee", MaxFlee);
            jObject.AddIfNotNull("walk_speed_multiplier", WalkSpeedMultiplier);
            jObject.AddIfNotNull("sprint_speed_multiplier", SprintSpeedMultiplier);
            jObject.AddIfNotNull("probability_per_strength", ProbabilityPerStrength);
            jObject.AddIfNotNull("ignore_visibility", IgnoreVisibility);

            return new JProperty(Name, jObject);
        }
    }
}

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
        public EntityTypes[] EntityTypes { get; set; }
        public double? MaxDist { get; set; }
        public double? MaxFlee { get; set; }
        public double? WalkSpeedMultiplier { get; set; }
        public double? SprintSpeedMultiplier { get; set; }
        public double? ProbabilityPerStrength { get; set; }
        public bool? IgnoreVisibility { get; set; }

        public BehaviorAvoidMobType(params EntityTypes[] entityTypes) {
            EntityTypes = entityTypes;
        }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EntityTypes != null && EntityTypes.Length > 0) jObject.Add("entity_types", JArray.FromObject(Array.ConvertAll(EntityTypes, item => (JObject)item)));
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

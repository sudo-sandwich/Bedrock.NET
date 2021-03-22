using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorNearestAttackableTarget : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.nearest_attackable_target";
            }
        }

        public int Priority { get; set; }
        public IList<EntityType> EntityTypes { get; set; } = new List<EntityType>();
        public double? WithinRadius { get; set; }
        public int? AttackInterval { get; set; }
        public bool? MustSee { get; set; }
        public double? MustSeeForgetDuration { get; set; }
        public bool? MustReach { get; set; }
        public bool? ReselectTargets { get; set; }
        public int? ScanInterval { get; set; }
        public double? TargetSearchHeight { get; set; }
        public double? PersistTime { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EntityTypes != null && EntityTypes.Count > 0) jObject.Add("entity_types", EntityTypes.ToJArray());
            jObject.AddIfNotNull("within_radius", WithinRadius);
            jObject.AddIfNotNull("attack_interval", AttackInterval);
            jObject.AddIfNotNull("must_see", MustSee);
            jObject.AddIfNotNull("must_see_forget_duration", MustSeeForgetDuration);
            jObject.AddIfNotNull("must_reach", MustReach);
            jObject.AddIfNotNull("reselect_targets", ReselectTargets);
            jObject.AddIfNotNull("scan_interval", ScanInterval);
            jObject.AddIfNotNull("target_search_height", TargetSearchHeight);
            jObject.AddIfNotNull("persist_time", PersistTime);

            return new JProperty(Name, jObject);
        }
    }
}

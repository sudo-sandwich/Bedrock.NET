using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorMeleeAttack : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.melee_attack";
            }
        }

        public int Priority { get; set; }
        public int? MeleeFOV { get; set; }
        public double? MaxDistance { get; set; } //i have no idea if this is a double or an int, just using double for now. thanks minecraft documentation for being helpful as always
        public double? RandomStopInterval { get; set; }
        public double? ReachMultiplier { get; set; }
        public bool? RequireCompletePath { get; set; }
        public double? SpeedMultiplier { get; set; }
        public bool? TrackTarget { get; set; }
        public double? LookDistance { get; set; }
        public double? TargetDistance { get; set; } //target_dist in json
        public double? UntrackableCooldownDelay { get; set; } //i have no idea if this is a double or an int, just using double for now. thanks minecraft documentation for being helpful as always
        //bridge lists a field called "target_tracking" here with no type. no idea what its for or its type so im leaving it out
        public EntityEvent OnAttack { get; set; } //again, no type, just going to assume its an event

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("melee_fov", MeleeFOV);
            jObject.AddIfNotNull("max_dist", MaxDistance);
            jObject.AddIfNotNull("random_stop_interval", RandomStopInterval);
            jObject.AddIfNotNull("reach_multiplier", ReachMultiplier);
            jObject.AddIfNotNull("require_complete_path", RequireCompletePath);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("track_target", TrackTarget);
            jObject.AddIfNotNull("look_distance", LookDistance);
            jObject.AddIfNotNull("target_dist", TargetDistance);
            jObject.AddIfNotNull("untrackable_cooldown_delay", UntrackableCooldownDelay);
            jObject.AddIfNotNull("on_attack", OnAttack?.Name);

            return new JProperty(Name, jObject);
        }
    }
}

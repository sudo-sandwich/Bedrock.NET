using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorKnockbackRoar : IBehavior {
        public string Name => "minecraft:behavior.knockback_roar";

        public int Priority { get; set; }
        public double? AttackTime { get; set; }
        public double? CooldownTime { get; set; }
        public double? Duration { get; set; }
        public int? KnockbackDamage { get; set; }
        public int? KnockbackRange { get; set; }
        public int? KnockbackStrength { get; set; }
        public IFilter KnockbackFilters { get; set; }
        public IFilter DamageFilters { get; set; }
        public string OnRoarEnd { get; set; }
        public string OnRoarEndTarget { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.Add("priority", Priority);
            jObject.AddIfNotNull("attack_time", AttackTime);
            jObject.AddIfNotNull("cooldown_time", CooldownTime);
            jObject.AddIfNotNull("duration", Duration);
            jObject.AddIfNotNull("knockback_damage", KnockbackDamage);
            jObject.AddIfNotNull("knockback_range", KnockbackRange);
            jObject.AddIfNotNull("knockback_strength", KnockbackStrength);
            jObject.AddIfNotNull("knockback_filters", KnockbackFilters);
            jObject.AddIfNotNull("damage_filters", DamageFilters);

            if (OnRoarEnd != null || OnRoarEndTarget != null) {
                JObject eventJObject = new JObject();
                eventJObject.AddIfNotNull("event", OnRoarEnd);
                eventJObject.AddIfNotNull("target", OnRoarEndTarget);
                jObject.Add(new JProperty("on_roar_end", eventJObject));
            }

            return new JProperty(Name, jObject);
        }
    }
}

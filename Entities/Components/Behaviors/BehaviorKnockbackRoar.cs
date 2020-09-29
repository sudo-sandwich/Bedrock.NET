using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorKnockbackRoar : IBehavior {
        public string Name => "minecraft:behavior.knockback_roar";

        public int Priority { get; set; }
        public double? AttackTime { get; set; }
        public double? CooldownTime { get; set; }
        public double? Duration { get; set; }
        public int? KnockbackDamage { get; set; }
        public int? KnockbackRange { get; set; }
        public int? KnockbackStrength { get; set; }
        public EntityEvent OnRoarEnd { get; set; }
        public Filter KnockbackFilters { get; set; }
        public Filter DamageFilters { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.Add("priority", Priority);
            jObject.AddIfNotNull("attack_time", AttackTime);
            jObject.AddIfNotNull("cooldown_time", CooldownTime);
            jObject.AddIfNotNull("duration", Duration);
            jObject.AddIfNotNull("knockback_damage", KnockbackDamage);
            jObject.AddIfNotNull("knockback_range", KnockbackRange);
            jObject.AddIfNotNull("knockback_strength", KnockbackStrength);
            jObject.AddIfNotNull("on_roar_end", OnRoarEnd?.GetAttribute());
            jObject.AddIfNotNull("knockback_filters", KnockbackFilters);
            jObject.AddIfNotNull("damage_filters", DamageFilters);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class DamageSensorTrigger : IJObject {
        public IFilter Filters { get; set; }
        public EntityEvent Event { get; set; }
        public string Target { get; set; }
        public string Cause { get; set; }
        public bool? DealsDamage { get; set; }
        public double? DamageMultiplier { get; set; }
        //on_damage_sound_event not implemented yet
        //public string OnDamageSoundEvent { get; set; }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            if (Filters != null || Event != null || Target != null) {
                JObject onDamage = new JObject();
                jObject.Add("on_damage", onDamage);
                onDamage.AddIfNotNull(Filters);
                onDamage.AddIfNotNull("event", Event?.Name);
                onDamage.AddIfNotNull("target", Target);
            }

            jObject.AddIfNotNull("cause", Cause);
            jObject.AddIfNotNull("deals_damage", DealsDamage);
            jObject.AddIfNotNull("damage_multiplier", DamageMultiplier);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}

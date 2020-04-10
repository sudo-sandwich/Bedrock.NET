using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class DamageSensorTrigger : IJToken {
        public Filter Filter { get; set; }
        public bool? DealsDamage { get; set; }
        public EntityEvent Event { get; set; }

        public DamageSensorTrigger() { }

        public DamageSensorTrigger(Filter filter, bool dealsDamage = false, EntityEvent triggerEvent = null) {
            Filter = filter;
            DealsDamage = dealsDamage;
            Event = triggerEvent;
        }

        public static implicit operator JObject(DamageSensorTrigger dst) {
            return dst?.ToJObject();
        }

        public static implicit operator JToken(DamageSensorTrigger dst) {
            return dst?.ToJToken();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            if (Filter != null && Event != null) {
                JObject onDamage = new JObject();
                jObject.Add(new JProperty("on_damage", onDamage));
                onDamage.AddIfNotNull(Filter);
                onDamage.AddIfNotNull("event", Event?.Name);
            }

            jObject.AddIfNotNull("deals_damage", DealsDamage);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}

using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class DamageCondition : IJToken {
        public Filter Filter { get; set; }
        public string Cause { get; set; }
        public int? DamagePerTick { get; set; }

        public DamageCondition(Filter filter = null, string cause = null, int? damagePerTick = null) {
            Filter = filter;
            Cause = cause;
            DamagePerTick = damagePerTick;
        }

        public static implicit operator JObject(DamageCondition dc) {
            return dc?.ToJObject();
        }

        public static implicit operator JToken(DamageCondition dc) {
            return dc?.ToJToken();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull(Filter);
            jObject.AddIfNotNull("cause", Cause);
            jObject.AddIfNotNull("damage_per_tick", DamagePerTick);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}

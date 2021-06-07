using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class HealableItem : IJToken {
        public string Item { get; set; }
        public int? HealAmount { get; set; }
        public IFilter Filters { get; set; }

        public HealableItem(string item, int? healAmount = null, IFilter filters = null) {
            Item = item;
            HealAmount = healAmount;
            Filters = filters;
        }

        public static implicit operator JObject(HealableItem hi) {
            return hi?.ToJObject();
        }

        public static implicit operator JToken(HealableItem hi) {
            return hi?.ToJToken();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("item", Item);
            jObject.AddIfNotNull("heal_amount", HealAmount);
            jObject.AddIfNotNull(Filters);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}

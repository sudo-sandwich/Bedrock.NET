using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class HealableItem : IJObject {
        public string Item { get; set; }
        public int? HealAmount { get; set; }
        public IFilter Filters { get; set; }

        public HealableItem(string item, int? healAmount = null, IFilter filters = null) {
            Item = item;
            HealAmount = healAmount;
            Filters = filters;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("item", Item);
            jObject.AddIfNotNull("heal_amount", HealAmount);
            jObject.AddIfNotNull(Filters);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}

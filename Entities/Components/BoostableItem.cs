using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class BoostableItem : IJToken {
        public string Item { get; set; }
        public int Damage { get; set; }
        public string ReplaceItem { get; set; }

        public BoostableItem(string item, int damage, string replaceItem) {
            Item = item;
            Damage = damage;
            ReplaceItem = replaceItem;
        }

        public JObject ToJObject() => new JObject() { { "item", Item }, { "damage", Damage }, { "replace_item", ReplaceItem } };

        public JToken ToJToken() => ToJObject();

        public static implicit operator JObject(BoostableItem bi) {
            return bi?.ToJObject();
        }

        public static implicit operator JToken(BoostableItem bi) {
            return bi?.ToJToken();
        }
    }
}

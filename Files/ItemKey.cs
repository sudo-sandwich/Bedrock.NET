using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class ItemKey : IJToken, IEquatable<ItemKey> {
        public string Item { get; set; }
        public int? Data { get; set; }

        public ItemKey(string item, int? data = null) {
            Item = item;
            Data = data;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject() {
                { "item", Item }
            };

            jObject.AddIfNotNull("data", Data);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        //stolen from here: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/263416#263416
        public override int GetHashCode() {
            unchecked {
                int hash = 97;
                hash = hash * 113 + Item.GetHashCode();
                hash = hash * 113 + Data == null ? 0 : (int)Data;
                return hash;
            }
        }

        public bool Equals(ItemKey other) {
            if (other == null) {
                return false;
            }
            return other.Item == Item && other.Data == Data;
        }

        public override bool Equals(object obj) {
            return Equals(obj as ItemKey);
        }
    }
}

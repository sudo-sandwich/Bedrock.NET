using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class FeedItem : IJToken {
        public string Item { get; set; }
        public double TemperMod { get; set; }

        public FeedItem(string item, double temperMod) {
            Item = item;
            TemperMod = temperMod;
        }

        public static implicit operator JObject(FeedItem fi) {
            return fi?.ToJObject();
        }

        public static implicit operator JToken(FeedItem fi) {
            return fi?.ToJToken();
        }

        public JObject ToJObject() {
            return new JObject() { { "item", Item }, { "temper_mod", TemperMod } };
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}

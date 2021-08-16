using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class FeedItem : IJObject {
        public string Item { get; set; }
        public double TemperMod { get; set; }

        public FeedItem(string item, double temperMod) {
            Item = item;
            TemperMod = temperMod;
        }

        public JObject ToJObject() => new JObject() { { "item", Item }, { "temper_mod", TemperMod } };

        public JToken ToJToken() => ToJObject();
    }
}

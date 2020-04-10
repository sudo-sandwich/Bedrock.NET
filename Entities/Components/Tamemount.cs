using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Tamemount : IComponent {
        public string Name {
            get {
                return "minecraft:tamemount";
            }
        }

        public int? MinTemper { get; set; }
        public int? MaxTemper { get; set; }
        public string FeedText { get; set; }
        public string RideText { get; set; }
        public int? AttemptTemperMod { get; set; }
        public FeedItem[] FeedItems { get; set; }
        public string[] AutoRejectItems { get; set; }
        public EntityEvent TameEvent { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("min_temper", MinTemper);
            jObject.AddIfNotNull("max_temper", MaxTemper);
            jObject.AddIfNotNull("feed_text", FeedText);
            jObject.AddIfNotNull("ride_text", RideText);
            jObject.AddIfNotNull("attempt_temper_mod", AttemptTemperMod);
            if (FeedItems != null && FeedItems.Length > 0) jObject.Add("feed_items", JArray.FromObject(Array.ConvertAll(FeedItems, item => (JObject)item)));
            if (AutoRejectItems != null && AutoRejectItems.Length > 0) jObject.Add("auto_reject_items", JArray.FromObject(Array.ConvertAll(AutoRejectItems, item => (JObject)item)));
            jObject.AddIfNotNull("tame_event", TameEvent?.GetAttribute());

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorTempt : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.tempt";
            }
        }

        public int Priority { get; set; }
        public double? SpeedMultiplier { get; set; }
        public double? WithinRadius { get; set; }
        public bool? CanGetScared { get; set; }
        public bool? CanTemptVertically { get; set; }
        public string[] Items { get; set; }

        public BehaviorTempt(params string[] items) {
            Items = items;
        }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("within_radius", WithinRadius);
            jObject.AddIfNotNull("can_get_scared", CanGetScared);
            jObject.AddIfNotNull("can_tempt_vertically", CanTemptVertically);
            if (Items != null && Items.Length > 0) jObject.Add("items", new JArray(Items));

            return new JProperty(Name, jObject);
        }
    }
}

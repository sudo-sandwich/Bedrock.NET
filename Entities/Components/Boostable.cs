using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Boostable : IComponent {
        public string Name => "minecraft:boostable";

        public double? SpeedMultiplier { get; set; }
        public double? Duration { get; set; }
        public IList<BoostableItem> BoostItems { get; set; } = new List<BoostableItem>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("duration", Duration);
            jObject.Add("boost_items", BoostItems.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}

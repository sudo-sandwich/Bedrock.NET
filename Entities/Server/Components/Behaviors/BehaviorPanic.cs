using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorPanic : IBehavior {
        public string Name => "minecraft:behavior.panic";

        public int Priority { get; set; }
        public bool? Force { get; set; }
        public bool? IgnoreMobDamage { get; set; }
        public bool? PreferWater { get; set; }
        public double? SpeedMultiplier { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("priority", Priority);
            jObject.AddIfNotNull("force", Force);
            jObject.AddIfNotNull("ignore_mob_damage", IgnoreMobDamage);
            jObject.AddIfNotNull("prefer_water", PreferWater);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);

            return new JProperty(Name, jObject);
        }
    }
}

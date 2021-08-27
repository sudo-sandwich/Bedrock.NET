using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorRunAroundLikeCrazy : IBehavior {
        public string Name => "minecraft:behavior.run_around_like_crazy";
        public int Priority { get; set; }

        public double? SpeedMultiplier { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("priority", Priority);
            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);

            return new JProperty(Name, jObject);
        }
    }
}

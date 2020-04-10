using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorGoHome : IBehavior {
        public string Name {
            get {
                return "minecraft:behavior.go_home";
            }
        }

        public int Priority { get; set; }
        public double? SpeedMultiplier { get; set; }
        public int? Interval { get; set; }
        public double? GoalRadius { get; set; }
        public EntityEvent OnHome { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("speed_multiplier", SpeedMultiplier);
            jObject.AddIfNotNull("interval", Interval);
            jObject.AddIfNotNull("goal_radius", GoalRadius);
            jObject.AddIfNotNull("on_home", OnHome?.GetAttribute());

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorRangedAttack : IBehavior {
        public string Name => "minecraft:behavior.ranged_attack";

        public int Priority { get; set; }
        public double? AttackIntervalMin { get; set; }
        public double? AttackIntervalMax { get; set; }
        public double? AttackRadius { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("attack_interval_min", AttackIntervalMin);
            jObject.AddIfNotNull("attack_interval_max", AttackIntervalMax);
            jObject.AddIfNotNull("attack_radius", AttackRadius);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Entities.Components {
    public class HurtOnCondition : IComponent {
        public string Name {
            get {
                return "minecraft:hurt_on_condition";
            }
        }

        public IList<DamageCondition> DamageConditions { get; set; } = new List<DamageCondition>();

        public HurtOnCondition(params DamageCondition[] damageConditions) {
            DamageConditions = new List<DamageCondition>(damageConditions);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (DamageConditions != null && DamageConditions.Count > 0) jObject.Add("damage_conditions", DamageConditions.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}

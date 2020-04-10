using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class HurtOnCondition : IComponent {
        public string Name {
            get {
                return "minecraft:hurt_on_condition";
            }
        }

        public DamageCondition[] DamageConditions { get; set; }

        public HurtOnCondition(params DamageCondition[] damageConditions) {
            DamageConditions = damageConditions;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (DamageConditions != null && DamageConditions.Length > 0) jObject.Add("damage_conditions", JArray.FromObject(Array.ConvertAll(DamageConditions, item => (JObject)item)));

            return new JProperty(Name, jObject);
        }
    }
}

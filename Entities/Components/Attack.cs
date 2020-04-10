using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Attack : IComponent {
        public string Name {
            get {
                return "minecraft:attack";
            }
        }

        public int? Damage { get; set; } //damage range not implemented
        public string EffectName { get; set; }
        public double? EffectDuration { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("damage", Damage);
            jObject.AddIfNotNull("effect_name", EffectName);
            jObject.AddIfNotNull("effect_duration", EffectDuration);

            return new JProperty(Name, jObject);
        }
    }
}

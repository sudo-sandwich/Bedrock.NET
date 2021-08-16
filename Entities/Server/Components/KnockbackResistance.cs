using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class KnockbackResistance : IComponent {
        public string Name => "minecraft:knockback_resistance";

        public double? Value { get; set; }
        public double? Max { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);
            jObject.AddIfNotNull("max", Max);

            return new JProperty(Name, jObject);
        }
    }
}

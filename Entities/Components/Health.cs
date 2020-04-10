using System;
using System.Collections.Generic;
using System.Text;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;

namespace Bedrock.Entities.Components {
    public class Health : IComponent {
        public string Name {
            get {
                return "minecraft:health";
            }
        }

        public int? Value { get; set; }
        public int? Max { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();
            jObject.AddIfNotNull("value", Value);
            jObject.AddIfNotNull("max", Max);

            return new JProperty(Name, jObject);
        }
    }
}

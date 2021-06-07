using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class IsStackable : IComponent {
        public string Name => "minecraft:is_stackable";

        public bool? Value { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);

            return new JProperty(Name, jObject);
        }
    }
}

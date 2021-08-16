using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Scale : IComponent {
        public string Name {
            get {
                return "minecraft:scale";
            }
        }

        public double? Value { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);

            return new JProperty(Name, jObject);
        }
    }
}

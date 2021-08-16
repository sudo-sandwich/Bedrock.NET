using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class FootSize : IComponent {
        public string Name {
            get {
                return "minecraft:foot_size";
            }
        }

        public int? Value { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);

            return new JProperty(Name, jObject);
        }
    }
}

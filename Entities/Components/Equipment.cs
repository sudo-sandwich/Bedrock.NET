using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Equipment : IComponent {
        public string Name => "minecraft:equipment";

        public string Table { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("table", Table);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Pushable : IComponent {
        public string Name {
            get {
                return "minecraft:pushable";
            }
        }
        
        public bool? IsPushable { get; set; }
        public bool? IsPushableByPiston { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("is_pushable", IsPushable);
            jObject.AddIfNotNull("is_pushable_by_piston", IsPushableByPiston);

            return new JProperty(Name, jObject);
        }
    }
}

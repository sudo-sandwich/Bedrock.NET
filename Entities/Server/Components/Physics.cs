using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Physics : IComponent {
        public string Name {
            get {
                return "minecraft:physics";
            }
        }

        public bool? HasGravity { get; set; }
        public bool? HasCollision { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("has_gravity", HasGravity);
            jObject.AddIfNotNull("has_collision", HasCollision);

            return new JProperty(Name, jObject);
        }
    }
}

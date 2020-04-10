using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class CollisionBox : IComponent {
        public string Name {
            get {
                return "minecraft:collision_box";
            }
        }

        public double? Width { get; set; }
        public double? Height { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Width != null) jObject.Add("width", Width);
            if (Height != null) jObject.Add("height", Height);

            return new JProperty(Name, jObject);
        }
    }
}

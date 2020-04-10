using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class TypeFamily : IComponent {
        public string Name {
            get {
                return "minecraft:type_family";
            }
        }

        public string[] Families { get; set; }

        public TypeFamily(params string[] families) {
            Families = families;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Families != null && Families.Length > 0) jObject.Add("family", new JArray(Families));

            return new JProperty(Name, jObject);
        }
    }
}

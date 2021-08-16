using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class TypeFamily : IComponent {
        public string Name {
            get {
                return "minecraft:type_family";
            }
        }

        public IList<string> Families { get; set; } = new List<string>();

        //DEPRECATED. use new TypeFamily() { Families = { "fam0", "fam1", "fam2" } }
        public TypeFamily(params string[] families) {
            Families.AddRange(families);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Families != null && Families.Count > 0) jObject.Add("family", new JArray(Families));

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Shooter : IComponent {
        public string Name => "minecraft:shooter";

        public string Def { get; set; }
        public string Type { get; set; }
        public int? AuxVal { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("def", Def);
            jObject.AddIfNotNull("type", Type);
            jObject.AddIfNotNull("aux_val", AuxVal);

            return new JProperty(Name, jObject);
        }
    }
}

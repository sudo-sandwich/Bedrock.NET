using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    // not even close to a full implmenation of this component
    public class Transformation : IComponent {
        public string Name => "minecraft:transformation";

        public string Into { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("into", Into);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Insomnia : IComponent {
        public string Name {
            get {
                return "minecraft:insomnia";
            }
        }

        public double? DaysUntilInsomnia { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("days_until_insomnia", DaysUntilInsomnia);

            return new JProperty(Name, jObject);
        }
    }
}

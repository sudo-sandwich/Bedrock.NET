using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Tameable : IComponent {
        public string Name {
            get {
                return "minecraft:tameable";
            }
        }

        public double? Probability { get; set; }
        public string[] TameItems { get; set; }
        public EntityEvent TameEvent { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("probability", Probability);
            jObject.AddIfNotNull("tame_items", TameItems);
            jObject.AddIfNotNull("tame_event", TameEvent.GetAttribute());

            return new JProperty(Name, jObject);
        }
    }
}

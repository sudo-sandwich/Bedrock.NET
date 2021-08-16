using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Tameable : IComponent {
        public string Name {
            get {
                return "minecraft:tameable";
            }
        }

        public double? Probability { get; set; }
        public IList<string> TameItems { get; set; } = new List<string>();
        public EntityEvent TameEvent { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("probability", Probability);
            if (TameItems != null && TameItems.Count > 0) jObject.Add("tame_items", new JArray(TameItems));
            jObject.AddIfNotNull("tame_event", TameEvent?.GetAttribute());

            return new JProperty(Name, jObject);
        }
    }
}

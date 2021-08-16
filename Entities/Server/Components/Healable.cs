using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Healable : IComponent {
        public string Name {
            get {
                return "minecraft:healable";
            }
        }

        public HealableItem[] Items { get; set; }
        public bool? ForceUse { get; set; }
        public IFilter Filters { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            JArray items = new JArray();
            jObject.AddIfNotNull("items", items);
            foreach (HealableItem item in Items) {
                items.Add(item.ToJToken());
            }

            jObject.AddIfNotNull("force_use", ForceUse);
            jObject.AddIfNotNull(Filters);

            return new JProperty(Name, jObject);
        }
    }
}

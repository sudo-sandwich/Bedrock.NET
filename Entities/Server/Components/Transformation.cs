using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    // not even close to a full implmenation of this component
    public class Transformation : IComponent {
        public string Name => "minecraft:transformation";

        public IList<string> ComponentsToAdd { get; set; } = new List<string>();
        public string Into { get; set; }
        public bool? DropEquipment { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (ComponentsToAdd.Count > 0) {
                jObject.Add(new JProperty("add", new JObject() { { "component_groups", new JArray(ComponentsToAdd) } }));
            }
            jObject.AddIfNotNull("drop_equipment", DropEquipment);
            jObject.AddIfNotNull("into", Into);

            return new JProperty(Name, jObject);
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class AddRider : IComponent {
        public string Name => "minecraft:addrider";

        public string EntityType { get; set; }
        public string SpawnEvent { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("entity_type", EntityType);
            jObject.AddIfNotNull("spawn_event", SpawnEvent);

            return new JProperty(Name, jObject);
        }
    }
}

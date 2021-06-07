using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class SpawnEntity : IComponent {
        public string Name => "minecraft:spawn_entity";

        public IList<SpawnEntityEntry> Entities { get; set; } = new List<SpawnEntityEntry>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("entities", Entities.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}

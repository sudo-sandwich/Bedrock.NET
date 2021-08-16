using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class InstantDespawn : IComponent {
        public string Name => "minecraft:instant_despawn";

        public bool? RemoveChildEntities { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("remove_child_entities", RemoveChildEntities);

            return new JProperty(Name, jObject);
        }
    }
}

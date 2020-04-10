using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Despawn : IComponent {
        public string Name {
            get {
                return "minecraft:despawn";
            }
        }

        public Filter Filter { get; set; }
        public bool? RemoveChildEntities { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull(Filter);
            jObject.AddIfNotNull("remove_child_entities", RemoveChildEntities);

            return new JProperty(Name, jObject);
        }
    }
}

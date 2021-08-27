using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Despawn : IComponent {
        public string Name {
            get {
                return "minecraft:despawn";
            }
        }

        public IFilter Filters { get; set; }
        public bool? RemoveChildEntities { get; set; }
        public int? DespawnFromDistanceMin { get; set; }
        public int? DespawnFromDistanceMax { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull(Filters?.ToJProperty());
            jObject.AddIfNotNull("remove_child_entities", RemoveChildEntities);

            if (DespawnFromDistanceMin != null || DespawnFromDistanceMin != null) {
                JObject despawnFromDistance = new JObject();
                despawnFromDistance.AddIfNotNull("min_distance", DespawnFromDistanceMin);
                despawnFromDistance.AddIfNotNull("max_distance", DespawnFromDistanceMax);

                jObject.Add(new JProperty("despawn_from_distance", despawnFromDistance));
            }

            return new JProperty(Name, jObject);
        }
    }
}

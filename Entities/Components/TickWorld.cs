using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class TickWorld : IComponent {
        public string Name {
            get {
                return "minecraft:tick_world";
            }
        }

        public int? Radius { get; set; }
        public double? DistanceToPlayers { get; set; }
        public bool? NeverDespawn { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("radius", Radius);
            jObject.AddIfNotNull("distance_to_players", DistanceToPlayers);
            jObject.AddIfNotNull("never_despawn", NeverDespawn);

            return new JProperty(Name, jObject);
        }
    }
}
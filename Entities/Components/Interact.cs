using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class Interact : IComponent {
        public string Name => "minecraft:interact";

        public IList<Interaction> Interactions { get; set; } = new List<Interaction>();

        public Interact(params Interaction[] interactions) {
            Interactions.AddRange(interactions);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            JArray interactions = new JArray();
            jObject.Add("interactions", interactions);

            foreach (Interaction interaction in Interactions) {
                interactions.Add(interaction.ToJObject());
            }

            return new JProperty(Name, jObject);
        }
    }
}

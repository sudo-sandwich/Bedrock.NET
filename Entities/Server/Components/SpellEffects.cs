using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class SpellEffects : IComponent {
        public string Name => "minecraft:spell_effects";

        public IList<SpellEffectsAdd> AddEffects { get; set; } = new List<SpellEffectsAdd>();
        public IList<string> RemoveEffects { get; set; } = new List<string>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (AddEffects.Count > 0) {
                jObject.Add("add_effects", AddEffects.ToJArray());
            }

            if (RemoveEffects.Count > 0) {
                jObject.Add("remove_effects", new JArray(RemoveEffects));
            }

            return new JProperty(Name, jObject);
        }
    }
}

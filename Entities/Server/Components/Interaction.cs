using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Interaction : IJObject {
        public string AddItems { get; set; }
        public double? Cooldown { get; set; }
        public double? CooldownAfterBeingAttacked { get; set; }
        public int? HurtItem { get; set; }
        public string InteractText { get; set; }
        public InteractEvent OnInteract { get; set; }
        public InteractParticle ParticleOnStart { get; set; }
        public string PlaySounds { get; set; }
        public string SpawnEntities { get; set; }
        public string SpawnItems { get; set; }
        public bool? Swing { get; set; }
        public string TransformToItem { get; set; }
        public bool? UseItem { get; set; }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            if (AddItems != null) {
                jObject.Add("add_items", new JObject() { { "table", AddItems } });
            }
            jObject.AddIfNotNull("cooldown", Cooldown);
            jObject.AddIfNotNull("cooldown_after_being_attacked", CooldownAfterBeingAttacked);
            jObject.AddIfNotNull("hurt_item", HurtItem);
            jObject.AddIfNotNull("interact_text", InteractText);
            jObject.AddIfNotNull("on_interact", OnInteract);
            jObject.AddIfNotNull("particle_on_start", ParticleOnStart?.ToJObject());
            jObject.AddIfNotNull("play_sounds", PlaySounds);
            jObject.AddIfNotNull("spawn_entities", SpawnEntities);
            if (SpawnItems != null) {
                jObject.Add("spawn_items", new JObject() { { "table", SpawnItems } });
            }
            jObject.AddIfNotNull("swing", Swing);
            jObject.AddIfNotNull("transform_to_item", TransformToItem);
            jObject.AddIfNotNull("use_item", UseItem);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}

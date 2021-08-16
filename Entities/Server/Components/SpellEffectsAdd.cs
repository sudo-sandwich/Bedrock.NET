using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class SpellEffectsAdd : IJObject {
        public string Effect { get; set; }
        public double? Duration { get; set; }
        public double? Amplifier { get; set; }
        public bool? Visible { get; set; }
        public bool? Ambient { get; set; }
        public bool? DisplayOnScreenAnimation { get; set; }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("effect", Effect);
            jObject.AddIfNotNull("duration", Duration);
            jObject.AddIfNotNull("amplifier", Amplifier);
            jObject.AddIfNotNull("visible", Visible);
            jObject.AddIfNotNull("ambient", Ambient);
            jObject.AddIfNotNull("display_on_screen_animation", DisplayOnScreenAnimation);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class SpellEffectsAdd : IJToken {
        public string Effect { get; set; }
        public int Duration { get; set; }
        public int Amplifier { get; set; }
        public bool Visible { get; set; }
        public bool Ambient { get; set; }
        public bool DisplayOnScreenAnimations { get; set; }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("effect", Effect);
            jObject.AddIfNotNull("duration", Duration);
            jObject.AddIfNotNull("amplifier", Amplifier);
            jObject.AddIfNotNull("visible", Visible);
            jObject.AddIfNotNull("ambient", Ambient);
            jObject.AddIfNotNull("display_on_screen_animations", DisplayOnScreenAnimations);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public static implicit operator JObject(SpellEffectsAdd sea) {
            return sea?.ToJObject();
        }

        public static implicit operator JToken(SpellEffectsAdd sea) {
            return sea?.ToJToken();
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class ParticleEffect {
        public ParticleDescription Particle { get; set; }
        public string Locator { get; set; }
        public string PreEffectScript { get; set; }

        public JToken Expression {
            get {
                JObject jObject = new JObject() {
                    { "effect", Particle.ShortName }
                };

                jObject.AddIfNotNull("locator", Locator);
                jObject.AddIfNotNull("pre_effect_script", PreEffectScript);

                return jObject;
            }
        }

        public ParticleEffect(ParticleDescription particle, string locator = null, string preEffectScript = null) {
            Particle = particle;
            Locator = locator;
            PreEffectScript = preEffectScript;
        }
    }
}

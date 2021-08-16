using Bedrock.Entities.Client;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class ParticleEffect : IJObject, IAnimationTimelineEvent {
        public ParticleDescription Particle { get; set; }
        public string Locator { get; set; }
        public string PreEffectScript { get; set; }
        public JToken AnimationEvent => ToJToken();

        public ParticleEffect(ParticleDescription particle, string locator = null, string preEffectScript = null) {
            Particle = particle;
            Locator = locator;
            PreEffectScript = preEffectScript;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject() {
                    { "effect", Particle.ShortName }
                };

            jObject.AddIfNotNull("locator", Locator);
            jObject.AddIfNotNull("pre_effect_script", PreEffectScript);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}

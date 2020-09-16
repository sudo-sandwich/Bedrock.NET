using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class InteractParticle : IJToken {
        public string ParticleType { get; set; }
        public double ParticleYOffset { get; set; }
        public bool ParticleOffsetTowardsIndicator { get; set; }

        public InteractParticle(string particleType, double particleYOffset, bool particleOffsetTowardsIndicator) {
            ParticleType = particleType;
            ParticleYOffset = particleYOffset;
            ParticleOffsetTowardsIndicator = particleOffsetTowardsIndicator;
        }

        public JObject ToJObject() {
            return new JObject() {
                { "particle_type", ParticleType },
                { "particle_y_offset", ParticleYOffset },
                { "particle_offset_towards_indicator", ParticleOffsetTowardsIndicator }
            };
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public static implicit operator JObject(InteractParticle pos) {
            return pos?.ToJObject();
        }

        public static implicit operator JToken(InteractParticle pos) {
            return pos?.ToJToken();
        }
    }
}

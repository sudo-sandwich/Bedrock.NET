using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class InteractParticle : IJObject {
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

        public JToken ToJToken() => ToJObject();
    }
}

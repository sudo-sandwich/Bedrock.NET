using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class EventChoice : IJToken {
        public double? MinActivationRange { get; set; }
        public double? MaxActivationRange { get; set; }
        public double? CooldownTime { get; set; }
        public double? CastDuration { get; set; }
        public string ParticleColor { get; set; }
        public int? Weight { get; set; }
        public string StartSoundEvent { get; set; }
        public IFilter Filters { get; set; }
        public IList<EventToSend> Sequence { get; set; } = new List<EventToSend>();

        public JToken ToJToken() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("min_activation_range", MinActivationRange);
            jObject.AddIfNotNull("max_activation_range", MaxActivationRange);
            jObject.AddIfNotNull("cooldown_time", CooldownTime);
            jObject.AddIfNotNull("cast_duration", CastDuration);
            jObject.AddIfNotNull("particle_color", ParticleColor);
            jObject.AddIfNotNull("weight", Weight);
            jObject.AddIfNotNull("start_sound_event", StartSoundEvent);
            jObject.AddIfNotNull(Filters);
            if (Sequence.Count > 0) jObject.Add("sequence", Sequence.ToJArray());

            return jObject;
        }
    }
}

using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class EventToSend : IJToken {
        public double? BaseDelay { get; set; }
        public string Event { get; set; }
        public string SoundEvent { get; set; }

        public JToken ToJToken() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("base_delay", BaseDelay);
            jObject.AddIfNotNull("event", Event);
            jObject.AddIfNotNull("sound_event", SoundEvent);

            return jObject;
        }
    }
}

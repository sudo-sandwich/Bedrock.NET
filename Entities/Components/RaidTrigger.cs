using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class RaidTrigger : IComponent {
        public string Name => "minecraft:raid_trigger";

        public EntityEvent Event { get; set; }
        public string Target { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            JObject triggeredEvent = new JObject();
            jObject.Add(new JProperty("triggered_event", triggeredEvent));

            triggeredEvent.AddIfNotNull("event", Event?.Name);
            triggeredEvent.AddIfNotNull("target", Target);

            return new JProperty(Name, jObject);
        }
    }
}

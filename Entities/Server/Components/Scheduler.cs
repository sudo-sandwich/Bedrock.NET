using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class Scheduler : IComponent {
        public string Name => "minecraft:scheduler";

        public double ? MinDelaySeconds { get; set; }
        public double? MaxDelaySeconds { get; set; }
        public IList<EnvironmentTrigger> ScheduledEvents { get; set; } = new List<EnvironmentTrigger>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("min_delay_seconds", MinDelaySeconds);
            jObject.AddIfNotNull("max_delay_seconds", MaxDelaySeconds);

            if (ScheduledEvents.Count > 0) {
                jObject.Add("scheduled_events", ScheduledEvents.ToJArray());
            }

            return new JProperty(Name, jObject);
        }
    }
}

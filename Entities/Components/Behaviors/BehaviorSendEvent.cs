using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorSendEvent : IBehavior {
        public string Name => "minecraft:behavior.send_event";
        public int Priority { get; set; }

        public IList<EventChoice> EventChoices { get; set; } = new List<EventChoice>();


        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EventChoices.Count > 0) jObject.Add("event_choices", EventChoices.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}
